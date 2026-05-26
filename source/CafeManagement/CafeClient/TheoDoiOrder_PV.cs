using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeClient
{
    public partial class TheoDoiOrder_PV : Form
    {
        public  TheoDoiOrder_PV()
        {
            InitializeComponent();
            this.Load += async (s, e) => {
                await LoadTableComboBox();
                await LoadOrders();
            };

        }
        private List<dynamic> fullOrderList = new List<dynamic>();

        private async Task LoadTableComboBox()
        {
            string response = await SocketClient.SendRequestAsync("GET_UNIQUE_TABLES");

            if (response.Contains("SUCCESS"))
            {
                var json = response.Split('|')[1];
                var tableIds = JsonConvert.DeserializeObject<List<int>>(json);

                List<string> displayList = new List<string>();
                displayList.Add("Tất cả bàn"); // Default option

                foreach (var id in tableIds)
                {
                    displayList.Add("Bàn " + id.ToString("D2")); // D2 formats 1 as "01"
                }

                // Use DataSource for a cleaner UI update
                cbSoBan.DataSource = displayList;
            }
        }

        private void ApplyFilters()
        {
            if (fullOrderList == null || fullOrderList.Count == 0) return;

            // --- Get Table Filter ---
            string selectedTable = cbSoBan.SelectedItem?.ToString();
            string tableNum = (selectedTable == null || selectedTable == "Tất cả bàn")
                              ? null
                              : selectedTable.Replace("Bàn ", "").Trim();

            // --- Get Status Filter ---
            string selectedStatus = cbTrangThai.SelectedItem?.ToString();
            string statusVal = (selectedStatus == null || selectedStatus == "Tất cả trạng thái")
                               ? null
                               : selectedStatus;

            // --- Apply Both Filters to the full list ---
            var filtered = fullOrderList.Where(x => {
                bool matchesTable = true;
                bool matchesStatus = true;

                // Table Check
                if (tableNum != null)
                {
                    string tenBan = (string)(x.banan is Newtonsoft.Json.Linq.JArray ? x.banan[0].tenban : x.banan?.tenban ?? "");
                    matchesTable = tenBan.Contains(tableNum);
                }

                // Status Check (Status is often stored as string or int in JSON)
                if (statusVal != null)
                {
                    matchesStatus = x.trangthai?.ToString() == statusVal;
                }

                return matchesTable && matchesStatus;
            }).ToList();

            // Re-use your display function!
            UpdateGridDisplay(filtered);
        }


        private async Task LoadOrders()
        {
            // Call the case we just made
            string response = await SocketClient.SendRequestAsync("GET_ORDERS_EXTENDED");

            if (response.Contains("SUCCESS"))
            {
                string json = response.Split('|')[1];
                fullOrderList = JsonConvert.DeserializeObject<List<dynamic>>(json);

                UpdateGridDisplay(fullOrderList);
                var rawData = JsonConvert.DeserializeObject<List<dynamic>>(json);

                var displayData = rawData.Select(x => {
                    string maHDStr = "N/A";

                    // 1. Log the raw value of x.hoadon to your console to see exactly what Supabase sends
                    // Console.WriteLine(x.hoadon?.ToString()); 

                    if (x.hoadon != null)
                    {
                        // Supabase often returns related items as a JArray []
                        if (x.hoadon is Newtonsoft.Json.Linq.JArray hList && hList.Count > 0)
                        {
                            maHDStr = hList[0]["mahd"]?.ToString() ?? "N/A";
                        }
                        // Sometimes it returns a single object {} if configured as a 1-to-1
                        else if (x.hoadon is Newtonsoft.Json.Linq.JObject hObj)
                        {
                            maHDStr = hObj["mahd"]?.ToString() ?? "N/A";
                        }
                    }

                    return new
                    {
                        MaDonHang = (int)x.madonhang,
                        MaHD = maHDStr,
                        TenBan = x.banan is Newtonsoft.Json.Linq.JArray ? x.banan[0]?.tenban : x.banan?.tenban ?? "N/A",
                        TrangThai = x.trangthai,
                        NgayOrder = x.ngayorder
                    };
                }).ToList();

                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = displayData;

                // Hide the MaDonHang column if you only want to show MaHD
                if (dgvDonHang.Columns.Contains("MaDonHang"))
                    dgvDonHang.Columns["MaDonHang"].Visible = false;

                dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

       
        private void UpdateGridDisplay(List<dynamic> data)
        {
            if (data == null) return;
            dgvDonHang.AutoGenerateColumns = false;

            var displayList = data.Select(x => {
                int totalQty = 0;

                // Use JArray explicitly to handle the JSON structure
                if (x.ctdonhang is Newtonsoft.Json.Linq.JArray items)
                {
                    foreach (var item in items)
                    {
                        // Access 'soluong' and convert safely to int
                        totalQty += (int)(item["soluong"] ?? 0);
                    }
                }

                return new
                {
                    MaDonHang = (int)x.madonhang,
                    MaHD = GetMaHD(x),
                    TenBan = x.banan != null ? (string)x.banan.tenban : "N/A",
                    // TEST: Convert it to a string explicitly
                    SoLuong = totalQty.ToString(),
                    TrangThai = x.trangthai?.ToString() ?? "",
                    NgayOrder = x.ngayorder
                };
            }).ToList();

            dgvDonHang.DataSource = null;
            MessageBox.Show($"First order total qty: {displayList[0].SoLuong}");
            dgvDonHang.DataSource = displayList;
        }
        


        private void cbSoBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private async void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Use a safer way to get the ID: 
            // Look for the column that is bound to the property "MaDonHang"
            int orderId = -1;
            foreach (DataGridViewColumn col in dgvDonHang.Columns)
            {
                if (col.DataPropertyName == "MaDonHang" || col.Name == "MaDonHang")
                {
                    var val = dgvDonHang.Rows[e.RowIndex].Cells[col.Index].Value;
                    if (val != null) orderId = Convert.ToInt32(val);
                    break;
                }
            }

            if (orderId == -1)
            {
                MessageBox.Show("Cannot find MaDonHang column. Check Designer Name property!");
                return;
            }
            string response = await SocketClient.SendRequestAsync($"GET_ORDER_DETAILS_EXTENDED|{orderId}");

            if (response.Contains("SUCCESS"))
            {
                var details = JsonConvert.DeserializeObject<List<dynamic>>(response.Split('|')[1]);

                lvDonHang.Items.Clear();
                // IMPORTANT: Ensure the view is set to Details mode
                lvDonHang.View = View.Details;
                lvDonHang.FullRowSelect = true;

                foreach (var item in details)
                {
                    // 1. Get Category Name
                    string tenLoai = "Unknown";
                    var menuObj = item.menu;
                    if (menuObj != null)
                    {
                        var firstMenu = menuObj is Newtonsoft.Json.Linq.JArray ? menuObj[0] : menuObj;
                        if (firstMenu?.loaimon != null)
                        {
                            var loaiObj = firstMenu.loaimon is Newtonsoft.Json.Linq.JArray ? firstMenu.loaimon[0] : firstMenu.loaimon;
                            tenLoai = loaiObj?.tenloai?.ToString() ?? "Unknown";
                        }
                    }

                    // 2. Create the item with the first column (TenLoai)
                    ListViewItem lvi = new ListViewItem(tenLoai);

                    // 3. Add the rest of the columns as SubItems
                    // Note: Use lowercase to match the DB columns exactly
                    lvi.SubItems.Add(item.soluong?.ToString() ?? "0");
                    lvi.SubItems.Add(item.ghichukhach?.ToString() ?? "");
                    lvi.SubItems.Add(item.ghichubep?.ToString() ?? "");

                    // For trangthaiitem (int), handle both potential casings
                    string status = item.trangthaiitem?.ToString() ?? item.TrangThaiItem?.ToString() ?? "0";
                    lvi.SubItems.Add(status);

                    lvDonHang.Items.Add(lvi);
                }
            }
        }


        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnLamMoi.Enabled = false;

            await LoadOrders();

            // Clear the detail list view since the main grid was refreshed
            lvDonHang.Items.Clear();

            btnLamMoi.Enabled = true;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xóa từ bảng trên.");
                return;
            }

            // 2. Get the Order ID (MaDonHang)
            // Note: Use the property name from your anonymous object in LoadOrders
            int orderId = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["MaDonHang"].Value);

            // 3. Confirm with user
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng #{orderId} không?",
                                         "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // 4. Send delete request to server
                string res = await SocketClient.SendRequestAsync($"DELETE_ORDER|{orderId}");

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show("Đã xóa đơn hàng thành công!");

                    // 5. Refresh the UI
                    await LoadOrders();
                    lvDonHang.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + res.Split('|')[1]);
                }
            }
        }

        private string GetMaHD(dynamic x)
        {
            if (x.hoadon != null)
            {
                // Handle the case where hoadon is a list/array
                if (x.hoadon is Newtonsoft.Json.Linq.JArray hList && hList.Count > 0)
                {
                    return hList[0]["mahd"]?.ToString() ?? "N/A";
                }
                // Handle the case where hoadon is a single object
                else if (x.hoadon is Newtonsoft.Json.Linq.JObject hObj)
                {
                    return hObj["mahd"]?.ToString() ?? "N/A";
                }
            }
            return "N/A";
        }
    }
}
