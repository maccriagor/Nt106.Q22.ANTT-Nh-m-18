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
    public partial class HoaDon_AD : Form
    {
        public HoaDon_AD()
        {
            InitializeComponent();
            LoadComboBoxData();
        }
        private void UpdateBillList(string response)
        {
            if (string.IsNullOrEmpty(response) || response.StartsWith("ERROR"))
            {
                // If there's an error or no data, just clear the list
                flpHoaDon.Controls.Clear();
                return;
            }

            try
            {
                List<HoaDon> bills = JsonConvert.DeserializeObject<List<HoaDon>>(response);
                DisplayBills(bills);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }
        private async void LoadComboBoxData()
        {
            // 1. Load Employees
            string nvRes = await SocketClient.SendRequestAsync("GET_ALL_NV");
            if (!nvRes.StartsWith("ERROR"))
            {
                var listNV = JsonConvert.DeserializeObject<List<nhanvien>>(nvRes);
                cbMaNV.DataSource = listNV;
                cbMaNV.DisplayMember = "manv"; // Show the ID in the dropdown
                cbMaNV.ValueMember = "manv";
            }

            // 2. Load Tables
            string banRes = await SocketClient.SendRequestAsync("GET_ALL_BAN");
            if (!banRes.StartsWith("ERROR"))
            {
                var listBan = JsonConvert.DeserializeObject<List<banan>>(banRes);
                cbMaBanAn.DataSource = listBan;
                cbMaBanAn.DisplayMember = "mabanan";
                cbMaBanAn.ValueMember = "mabanan";
            }
        }
        private void DisplayBills(List<HoaDon> bills)
        {
            flpHoaDon.Controls.Clear();
            foreach (var bill in bills)
            {
                ThongTinHoaDon card = new ThongTinHoaDon(bill);

                card.OnCardClicked += (s, e) =>
                {
                    txtMaHD.Text = bill.MaHD.ToString();
                    cbMaNV.Text = bill.MaNV.ToString();
                    cbMaBanAn.Text = bill.MaBanAn?.ToString();
                    dtpNgayXuat.Value = bill.NgayTao;
                };

             
                flpHoaDon.Controls.Add(card);
            }
        }


        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text)) return;

            if (MessageBox.Show("Xác nhận xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string res = await SocketClient.SendRequestAsync($"DELETE_BILL|{txtMaHD.Text}");
                if (res == "DELETE_SUCCESS") btnLamMoi_Click(null, null);
            }
        }



        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            cbMaNV.Text = "";
            cbMaBanAn.Text = "";
            dtpNgayXuat.Value = DateTime.Now;
            string response = await SocketClient.SendRequestAsync("GET_ALL_BILLS");
            UpdateBillList(response);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            btnLamMoi_Click(sender, e);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchId = txtTimKiem.Text.Trim(); // Replace with your actual search textbox name
            if (string.IsNullOrEmpty(searchId)) return;

            // Command: SEARCH_BILL_BY_ID|123
            string response = await SocketClient.SendRequestAsync($"SEARCH_BILL_BY_ID|{searchId}");

            if (response.StartsWith("ERROR"))
            {
                MessageBox.Show("Không tìm thấy hóa đơn!");
            }
            else
            {
                // UpdateBillList handles the JSON and calls DisplayBills
                UpdateBillList(response);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Basic Validation
                if (string.IsNullOrEmpty(txtMaHD.Text) || string.IsNullOrEmpty(cbMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã HD và Mã NV!");
                    return;
                }

                // 2. Check Foreign Keys using the updated database column name
                // We use "nhanvien" because your server-side 'if' block handles that name
                bool nvExists = await PrimaryKeyCheck.Exists("nhanvien", "manguoidung", int.Parse(cbMaNV.Text));

                if (!nvExists)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại trong hệ thống!");
                    return;
                }

                // 3. Construct the message
                // Make sure the order of parts matches your SocketServer case 
                // (CMD|MaHD|MaNV|MaBanAn|NgayXuat)
                string msg = $"SAVE_BILL|{txtMaHD.Text}|{cbMaNV.Text}|{cbMaBanAn.Text}|{dtpNgayXuat.Value:yyyy-MM-dd HH:mm:ss}";

                string response = await SocketClient.SendRequestAsync(msg);

                if (response == "SAVE_SUCCESS")
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Lỗi từ server: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            // Reuse the logic from btnThem
            btnThem_Click(sender, e);
        }
    }
}
