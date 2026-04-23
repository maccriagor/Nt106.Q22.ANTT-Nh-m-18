using CafeCommon;
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
    public partial class HoaDonPopup : Form
    {
        public Bill currentBill { get; set; }
        public HoaDonPopup()
        {
            InitializeComponent();
        }
        private void FillFormWithData(Bill bill)
        {
            txtMaHoaDon.Text = bill.MaHD.ToString();
            // Use SelectedItem for simple List<int> data sources
            cbMaNV.SelectedItem = bill.MaNV;
            cbMaBanAn.SelectedItem = bill.MaBanAn;
            cbMaDonHang.SelectedItem = bill.MaDonhang;
            cbMaKH.SelectedItem = bill.MaKH;
            cbMaKM.SelectedItem = bill.MaKM;

            // Fill other fields
            dtpNgayTao.Value = bill.NgayTao;
            txtTongTien.Text = bill.TongTien.ToString();
            lblSoTienGiam.Text = $"{bill.SoTienGiam:N0} đ";
            txtThanhTien.Text = bill.ThanhTien.ToString();
            cbTrangThai.SelectedItem = bill.TrangThai;
            cbPhuongThucThanhToan.SelectedItem = bill.PhuongThucThanhToan;
        }
        private async Task<List<int>> GetIdsFromServer(string command)
        {
            string response = await SocketClient.SendRequestAsync(command);

            // If the server sent an error string instead of a JSON list
            if (response.StartsWith("ERROR|"))
            {
                MessageBox.Show($"Lỗi từ Server ({command}): " + response.Replace("ERROR|", ""));
                return new List<int>();
            }

            return JsonConvert.DeserializeObject<List<int>>(response);
        }
        private async Task LoadDataToComboBoxes()
        {
            cbMaNV.DataSource = await GetIdsFromServer("GET_EMPLOYEES");
            cbMaBanAn.DataSource = await GetIdsFromServer("GET_TABLES");
            cbMaDonHang.DataSource = await GetIdsFromServer("GET_ORDERS");
            cbMaKH.DataSource = await GetIdsFromServer("GET_CUSTOMERS");
            cbMaKM.DataSource = await GetIdsFromServer("GET_PROMOTIONS");
        }
        private void RunRecalculation()
        {
            if (decimal.TryParse(txtTongTien.Text, out decimal tongTien))
            {
                string loaiKM = "Phần trăm"; // This should ideally come from the selected Promotion data
                decimal giaTriKM = 10;       // Example: 10%

                UpdateBillTotals(tongTien, loaiKM, giaTriKM);
            }
        }
        private async void HoaDonPopup_Load(object sender, EventArgs e)
        {

            txtTongTien.TextChanged += (s, e) => RunRecalculation();
            cbMaKM.SelectedIndexChanged += (s, e) => RunRecalculation();
            dtpNgayTao.Value = DateTime.Now;
            cbTrangThai.Items.AddRange(new string[] { "Đang xử lý", "Chưa thanh toán", "Đã thanh toán" });
            cbPhuongThucThanhToan.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            await LoadDataToComboBoxes();
            // Check if we are EDITING
            if (currentBill != null)
            {
                this.Text = "Sửa Hóa Đơn";
                txtMaHoaDon.ReadOnly = true; // Protect the Primary Key
                FillFormWithData(currentBill);
            }
            else
            {
                this.Text = "Thêm Hóa Đơn Mới";
                cbTrangThai.SelectedIndex = 0; // Default to "Đang xử lý"
            }
        }

        public void lblKM_Click(object sender, EventArgs e)
        {

        }
        public void label7_Click(object sender, EventArgs e) { }
        public void UpdateBillTotals(decimal tongTien, string loaiKM, decimal giaTriKM)
        {
            decimal giam = (loaiKM == "Phần trăm") ? tongTien * (giaTriKM / 100) : giaTriKM;
            decimal thanhTien = Math.Max(0, tongTien - giam);

            // Update the Label text visually
            lblSoTienGiam.Text = string.Format("{0:N0} đ", giam);

            // STORE the raw value in the Tag so we don't have to parse " đ" later
            lblSoTienGiam.Tag = giam;

            txtThanhTien.Text = thanhTien.ToString("N0");
        }



        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation First: Stop the code immediately if data is missing
            if (cbMaDonHang.SelectedItem == null || cbMaNV.SelectedItem == null || cbMaBanAn.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ các thông tin bắt buộc (Nhân viên, Đơn hàng, Bàn)!");
                return;
            }

            // 2. Initialize Object
            if (currentBill == null)
            {
                currentBill = new Bill();
            }

            try
            {
                // 3. Assignment: Now it is safe to cast because we validated above
                currentBill.MaHD = int.Parse(txtMaHoaDon.Text);
                currentBill.MaNV = (int)cbMaNV.SelectedItem;
                currentBill.MaBanAn = (int)cbMaBanAn.SelectedItem;
                currentBill.MaDonhang = (int)cbMaDonHang.SelectedItem;

                // Use SelectedItem for consistency since we removed DisplayMember/ValueMember
                currentBill.MaKH = cbMaKH.SelectedItem as int?;

                currentBill.NgayTao = dtpNgayTao.Value;
                currentBill.TongTien = decimal.Parse(txtTongTien.Text);

                // Use the Tag property we set in UpdateBillTotals to avoid string parsing errors
                currentBill.SoTienGiam = lblSoTienGiam.Tag != null ? (decimal)lblSoTienGiam.Tag : 0;

                currentBill.ThanhTien = decimal.Parse(txtThanhTien.Text);
                currentBill.TrangThai = cbTrangThai.SelectedItem.ToString();
                if (cbPhuongThucThanhToan.SelectedItem != null)
                {
                    currentBill.PhuongThucThanhToan = cbPhuongThucThanhToan.SelectedItem.ToString();
                }
                else
                {
                    // Provide a default or show a warning
                    currentBill.PhuongThucThanhToan = "Tiền mặt";
                }

                // 4. Build the Message String
                string maKHStr = currentBill.MaKH?.ToString() ?? "NULL";
                string maKMStr = cbMaKM.SelectedItem?.ToString() ?? "NULL";

                string message = $"SAVE_BILL|{currentBill.MaHD}|{currentBill.MaDonhang}|{currentBill.MaBanAn}|{currentBill.MaNV}|" +
                                 $"{maKHStr}|{currentBill.NgayTao:yyyy-MM-dd HH:mm:ss}|{currentBill.TongTien}|" +
                                 $"{currentBill.SoTienGiam}|{currentBill.ThanhTien}|{currentBill.TrangThai}|{currentBill.PhuongThucThanhToan}|{maKMStr}";

                // 5. Send to Server
                string response = await SocketClient.SendRequestAsync(message);

                if (response == "SAVE_SUCCESS")
                {
                    MessageBox.Show("Lưu thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // This will catch the "23503" or "23505" errors from Supabase
                    MessageBox.Show("Lỗi từ Server: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + ex.Message);
            }
        }

        private void lblSoTienGiam_Click(object sender, EventArgs e)
        {

        }

        private async void btnxoa_Click(object sender, EventArgs e)
        {
            if (currentBill == null || currentBill.MaHD == 0)
            {
                // Just close the popup. Since it hasn't been saved, 
                // "Deleting" it is just cancelling the entry.
                this.Close();
                return;
            }

            // Otherwise, it's an existing record. Ask the server to remove it.
            var confirm = MessageBox.Show($"Xóa hóa đơn {currentBill.MaHD}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string response = await SocketClient.SendRequestAsync($"DELETE_BILL|{currentBill.MaHD}");
                if (response == "DELETE_SUCCESS")
                {
                    this.DialogResult = DialogResult.OK; // Trigger refresh in main form
                    this.Close();
                }
            }
        }
    }
}
