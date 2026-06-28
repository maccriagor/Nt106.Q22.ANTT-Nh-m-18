using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CafeCommon;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeClient
{
    public partial class KhachHang_PV : Form
    {
        private List<KhachHang> fullCustomerList = new List<KhachHang>();
        public KhachHang_PV()
        {
            InitializeComponent();

            this.Load += async (s, e) =>
            {
                await LoadCustomers();
            };
        }
        private async Task LoadCustomers()
        {
            try
            {
                // Sending the specific request for customers
                string response = await SocketClient.SendRequestAsync("GET_CUSTOMERS");

                if (response.StartsWith("SUCCESS"))
                {
                    string json = response.Split('|')[1];
                    fullCustomerList = JsonConvert.DeserializeObject<List<KhachHang>>(json);

                    dgvKhachHang.DataSource = null;
                    dgvKhachHang.DataSource = fullCustomerList;
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    string[] hiddenCols = { "BaseUrl", "TableName", "PrimaryKey", "RequestClientOptions" };
                    foreach (var colName in hiddenCols)
                    {
                        if (dgvKhachHang.Columns.Contains(colName))
                            dgvKhachHang.Columns[colName].Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load customers: " + response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var row = dgvKhachHang.Rows[e.RowIndex];


                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
                txtMaKH.Tag = row.Cells["MaKH"].Value;


                txtTenKH.Text = row.Cells["TenKH"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();


                if (row.Cells["DiemTichLuy"].Value != null)
                {
                    txtDiemTichLuy.Text = row.Cells["DiemTichLuy"].Value.ToString();
                }


                if (row.Cells["NgayDangKy"].Value != null)
                {
                    dtpNgayDangKi.Value = Convert.ToDateTime(row.Cells["NgayDangKy"].Value);
                }
            }
        }

        private void ClearFields()
        {
            txtMaKH.Clear();
            txtMaKH.Tag = null;
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiemTichLuy.Clear();
            dtpNgayDangKi.Value = DateTime.Now;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            return true;
        }


        private async void btnXem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadCustomers();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var kh = new KhachHang
                {

                    MaKH = int.TryParse(txtMaKH.Text.Trim(), out int id) ? id : 0,
                    TenKH = txtTenKH.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    DiemTichLuy = int.TryParse(txtDiemTichLuy.Text, out int diem) ? diem : 0,
                    NgayDangKy = dtpNgayDangKi.Value
                };

                string request = "ADD_CUSTOMERS|" + JsonConvert.SerializeObject(kh);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                    ClearFields();
                    await LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + (res.Contains("|") ? res.Split('|')[1] : res), "Thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
                return;
            }



            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int id = (int)txtMaKH.Tag;
                    string res = await SocketClient.SendRequestAsync($"DELETE_CUSTOMERS|{id}");

                    if (res.Contains("SUCCESS"))
                    {
                        MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                        ClearFields();
                        await LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + (res.Contains("|") ? res.Split('|')[1] : res), "Thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống khi xóa: " + ex.Message);
                }
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng từ danh sách!");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var kh = new KhachHang
                {

                    MaKH = int.TryParse(txtMaKH.Text.Trim(), out int id) ? id : 0,
                    TenKH = txtTenKH.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    DiemTichLuy = int.TryParse(txtDiemTichLuy.Text, out int diem) ? diem : 0,
                    NgayDangKy = dtpNgayDangKi.Value
                };

                string request = "UPDATE_CUSTOMERS|" + JsonConvert.SerializeObject(kh);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                    ClearFields();
                    await LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + (res.Contains("|") ? res.Split('|')[1] : res), "Thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
 
            string key = txtTimKiem.Text.ToLower().Trim();

            //Tim kiem ma khach hang
            var filtered = fullCustomerList.Where(x =>
          string.IsNullOrEmpty(key) ||
          x.MaKH.ToString().Contains(key)
      ).ToList();


            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = filtered;

  
            string[] hiddenCols = { "BaseUrl", "TableName", "PrimaryKey", "RequestClientOptions" };
            foreach (var colName in hiddenCols)
            {
                if (dgvKhachHang.Columns.Contains(colName))
                    dgvKhachHang.Columns[colName].Visible = false;
            }

            txtTimKiem.Clear();
          
        }
    }
}
