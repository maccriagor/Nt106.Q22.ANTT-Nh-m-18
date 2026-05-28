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
        public TheoDoiOrder_PV()
        {
            InitializeComponent();
            this.Load += async (s, e) =>
            {
                await LoadTableComboBox();
                await LoadOrders();
            };

        }
        private List<dynamic> fullOrderList = new List<dynamic>();

        private async Task LoadTableComboBox()
        {
            string response = await SocketClient.SendRequestAsync("GET_UNIQUE_TABLES");

            if (response.StartsWith("SUCCESS"))
            {
                var json = response.Split('|')[1];

                // 1. Deserialize straight into a List of strings now
                var tableNames = JsonConvert.DeserializeObject<List<string>>(json);

                List<string> displayList = new List<string>();
                displayList.Add("Tất cả bàn"); // Default option

                // 2. Loop through and add the real database strings directly
                foreach (var name in tableNames)
                {
                    displayList.Add(name); // No more synthetic "Bàn " + ID formatting!
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
            var filtered = fullOrderList.Where(x =>
            {
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

            if (response.StartsWith("SUCCESS"))
            {
                string json = response.Split('|')[1];

                // Save to master list for filtering
                fullOrderList = JsonConvert.DeserializeObject<List<dynamic>>(json);

                // This handles calculating quantity AND finding MaHD via GetMaHD(x)
                UpdateGridDisplay(fullOrderList);

                // Keep your column adjustments here right after binding
                if (dgvDonHang.Columns.Contains("MaDonHang"))
                    dgvDonHang.Columns["MaDonHang"].Visible = false;

                dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void UpdateGridDisplay(List<dynamic> data)
        {
            if (data == null) return;
            dgvDonHang.AutoGenerateColumns = false;

            var displayList = data.Select(x =>
            {
                int totalQty = 0;

                // Calculate total items ordered
                if (x.ctdonhang is Newtonsoft.Json.Linq.JArray items)
                {
                    foreach (var item in items)
                    {
                        totalQty += (int)(item["soluong"] ?? 0);
                    }
                }

                // --- Convert numeric status to readable text ---
                string rawStatus = x.trangthai?.ToString() ?? "";
                string readableStatus = rawStatus switch
                {
                    "0" => "Chờ xác nhận",
                    "1" => "Đang chế biến",
                    "2" => "Hoàn thành",
                    "3" => "Đã hủy",
                    _ => "Không xác định" // Fallback case if something unexpected comes from DB
                };

                return new
                {
                    MaDonHang = (int)x.madonhang,
                    MaHD = GetMaHD(x),

                    // Safe array/object check for table name
                    TenBan = x.banan is Newtonsoft.Json.Linq.JArray ? x.banan[0]?.tenban : x.banan?.tenban ?? "N/A",

                    SoLuong = totalQty.ToString(),
                    TrangThai = readableStatus, // <--- Now uses the clean Vietnamese text!
                    NgayOrder = x.ngayorder
                };
            }).ToList();

            dgvDonHang.DataSource = null;
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

            if (response.StartsWith("SUCCESS"))
            {
                var details = JsonConvert.DeserializeObject<List<dynamic>>(response.Split('|')[1]);

                lvDonHang.Items.Clear();
                lvDonHang.View = View.Details;
                lvDonHang.FullRowSelect = true;

                foreach (var item in details)
                {
                    // 1. Get Item Name (tenmon) straight from the menu object
                    string tenMon = "Unknown";
                    var menuObj = item.menu;
                    if (menuObj != null)
                    {
                        // Handle whether Supabase returns menu relation as an array or single object
                        var firstMenu = menuObj is Newtonsoft.Json.Linq.JArray ? menuObj[0] : menuObj;
                        tenMon = firstMenu?.tenmon?.ToString() ?? "Unknown";
                    }

                    // 2. Create the item with the first column (TenMon instead of TenLoai)
                    ListViewItem lvi = new ListViewItem(tenMon);

                    // 3. Add the rest of the columns as SubItems
                    lvi.SubItems.Add(item.soluong?.ToString() ?? "0");
                    lvi.SubItems.Add(item.ghichukhach?.ToString() ?? "");
                    lvi.SubItems.Add(item.ghichubep?.ToString() ?? "");

                    // Convert status values to readable text (Chờ, Đang làm, Xong)
                    string rawItemStatus = item.trangthaiitem?.ToString() ?? item.TrangThaiItem?.ToString() ?? "";
                    string readableItemStatus = rawItemStatus switch
                    {
                        "0" => "Chờ",
                        "1" => "Đang làm",
                        "2" => "Xong",
                        _ => "Không xác định"
                    };
                    lvi.SubItems.Add(readableItemStatus);

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

                if (res.StartsWith("SUCCESS"))
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

        private void lvDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
