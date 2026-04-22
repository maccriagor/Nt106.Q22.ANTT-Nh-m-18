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
    public partial class Menu : Form
    {
        private int selectedMenuId = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private async Task LoadMenuData()
        {
            string res = await SocketClient.SendRequestAsync("GET_ALL_MENU");

            if (!res.StartsWith("ERROR"))
            {
                var list = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(res);

                dgvFood.AutoGenerateColumns = false; // Tắt tự tạo cột
                dgvFood.DataSource = list;

                // Tự động hiển thị món đầu tiên
                if (list != null && list.Count > 0)
                {
                    FillMenuToFields(list[0]);
                }
            }
            else
            {
                MessageBox.Show("Lỗi: " + res);
            }
        }

        //  Tạo hàm Helper để dùng chung (Tránh lặp code)
        private void FillMenuToFields(CafeCommon.Menu item)
        {
            tbMaMon.Text = item.MaMon.ToString();
            tbTenMon.Text = item.TenMon ?? "";
            nmGiaBan.Value = Convert.ToDecimal(item.Gia);
            txtMoTa.Text = item.MoTa ?? "";
            cbMaLoaiMon.Text = item.MaLoaiMon.ToString();
            cbTrangThai.Text = item.TrangThai ?? "";

            selectedMenuId = item.MaMon;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng ở client cho nhanh
            if (string.IsNullOrWhiteSpace(tbTenMon.Text))
            {
                MessageBox.Show("Hãy nhập tên món ăn!");
                return;
            }

            string cmd = $"ADD_MENU|{cbMaLoaiMon.Text}|{tbTenMon.Text}|{txtMoTa.Text}|{nmGiaBan.Value}|{cbTrangThai.Text}";
            string res = await SocketClient.SendRequestAsync(cmd);

            if (res == "SUCCESS")
            {
                MessageBox.Show("Thêm món thành công!", "Thông báo");
                await LoadMenuData();
                // Xóa trắng ô tên món để nhập món tiếp theo
                tbTenMon.Clear();
                tbTenMon.Focus();
            }
            else if (res.StartsWith("ADD_MENU_FAIL"))
            {
                // Lấy thông báo lỗi sau dấu gạch đứng
                string errorMsg = res.Split('|')[1];
                MessageBox.Show(errorMsg, "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tbTenMon.SelectAll();
                tbTenMon.Focus();
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống: " + res);
            }
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            await LoadMenuData();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMenuId == 0)
            {
                MessageBox.Show("Hãy chọn món cần xóa!");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa món '{tbTenMon.Text}' không?",
                                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string res = await SocketClient.SendRequestAsync($"DELETE_MENU|{selectedMenuId}");

                if (res == "SUCCESS")
                {
                    MessageBox.Show("Đã xóa món ăn khỏi thực đơn.");
                    selectedMenuId = 0; // Reset ID
                    await LoadMenuData();
                }
                else
                {
                    MessageBox.Show("Lỗi xóa: " + res);
                }
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMenuId == 0)
            {
                MessageBox.Show("Vui lòng chọn một món từ danh sách để sửa!");
                return;
            }

            // Gói tin: UPDATE_MENU|MaMon|MaLoaiMon|TenMon|MoTa|Gia|TrangThai
            string cmd = $"UPDATE_MENU|{selectedMenuId}|{cbMaLoaiMon.Text}|{tbTenMon.Text}|{txtMoTa.Text}|{nmGiaBan.Value}|{cbTrangThai.Text}";

            string res = await SocketClient.SendRequestAsync(cmd);

            if (res == "SUCCESS")
            {
                MessageBox.Show("Cập nhật món thành công!");
                await LoadMenuData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + res);
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            // Nếu để trống ô tìm kiếm, tự động load lại tất cả món ăn
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadMenuData();
                return;
            }

            string res = await SocketClient.SendRequestAsync($"SEARCH_MENU|{keyword}");

            if (!res.StartsWith("ERROR"))
            {
                var searchResult = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(res);
                dgvFood.DataSource = searchResult;

                if (searchResult.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy món nào khớp với tên này!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Lỗi tìm kiếm: " + res);
            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvFood.Rows[e.RowIndex];

                // Lấy đối tượng từ hàng đang chọn (DataBoundItem)
                var item = row.DataBoundItem as CafeCommon.Menu;
                if (item != null)
                {
                    FillMenuToFields(item);
                }
            }
        }
    }
}
