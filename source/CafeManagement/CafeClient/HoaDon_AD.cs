using CafeCommon;
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
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
            this.Load += async (s, e) => {
                await LoadComboBoxData();
                await UpdateBillList(); 
            };
        }

        private async Task LoadComboBoxData()
        {
            try
            {
                // 1. Load Employees (NhanVien)
                string resNV = await SocketClient.SendRequestAsync("GET_ALL_NV");
                if (resNV.StartsWith("SUCCESS"))
                {
                    string json = resNV.Split('|')[1];
                    var listNV = JsonConvert.DeserializeObject<List<nhanvien>>(json);

                    cbMaNV.DataSource = listNV;
                    cbMaNV.DisplayMember = "manv"; // Matches the C# property name
                    cbMaNV.ValueMember = "manv";
                }

                // 2. Load Tables (BanAn)
                string resBan = await SocketClient.SendRequestAsync("GET_ALL_BAN");
                if (resBan.StartsWith("SUCCESS"))
                {
                    string json = resBan.Split('|')[1];
                    var listBan = JsonConvert.DeserializeObject<List<banan>>(json);

                    cbMaBanAn.DataSource = listBan;
                    cbMaBanAn.DisplayMember = "mabanan";
                    cbMaBanAn.ValueMember = "mabanan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ComboBox: " + ex.Message);
            }
        }


        private async Task UpdateBillList() 
        {
            string response = await SocketClient.SendRequestAsync("GET_ALL_BILLS");

            if (response.StartsWith("SUCCESS"))
            {
                // Split by the pipe character and take the second part (the JSON)
                string json = response.Split('|')[1];
                List<HoaDon> bills = JsonConvert.DeserializeObject<List<HoaDon>>(json);

                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = bills;
            }
        }

       

        private async void btnXem_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            cbMaNV.Text = "";
            cbMaBanAn.Text = "";
            dtpNgayXuat.Value = DateTime.Now;
            string response = await SocketClient.SendRequestAsync("GET_ALL_BILLS");
            await UpdateBillList();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var bill = (HoaDon)dgvHoaDon.Rows[e.RowIndex].DataBoundItem;
                txtMaHD.Text = bill.MaHD.ToString();
                cbMaNV.Text = bill.MaNV.ToString();
                cbMaBanAn.Text = bill.MaBanAn?.ToString();
                dtpNgayXuat.Value = bill.NgayTao;
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchId = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchId))
            {
                await UpdateBillList(); // Show everything if search is empty
                return;
            }

            string response = await SocketClient.SendRequestAsync($"SEARCH_BILL_BY_ID|{searchId}");

            // Check if we got valid JSON data (not an error and not empty)
            if (!response.StartsWith("ERROR") && response != "[]")
            {
                // Bind the specific search result to the grid
                List<HoaDon> searchResults = JsonConvert.DeserializeObject<List<HoaDon>>(response);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = searchResults;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn có mã này!");
                dgvHoaDon.DataSource = null; // Clear the grid if nothing found
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
                    btnXem_Click(null, null);
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
    public static class PrimaryKeyCheck
    {
        public static async Task<bool> Exists(string tableName, string columnName, int id)
        {
            try
            {
                string request = $"CHECK_EXISTS|{tableName}|{columnName}|{id}";
                string response = await SocketClient.SendRequestAsync(request);
                return response == "EXISTS_TRUE";
            }
            catch { return false; }
        }
    }

    // Tiny models for the foreign key checks
    [Table("useraccount")]
    public class nhanvien : BaseModel
    {
        [PrimaryKey("manguoidung", false)]
        [Column("manguoidung")]
        public int manv { get; set; }
    }

    [Table("banan")]
    public class banan : BaseModel
    {
        [PrimaryKey("mabanan")]
        public int mabanan { get; set; }
    }

}
