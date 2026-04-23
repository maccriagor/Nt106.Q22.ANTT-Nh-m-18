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
        private List<CafeCommon.LoaiMon> categoryList = new List<CafeCommon.LoaiMon>();

        public Menu()
        {
            InitializeComponent();
        }

        private async void Menu_Load(object sender, EventArgs e)
        {

        }

        private async Task LoadMenuData()
        {
            // Tải danh mục về làm "từ điển" (Bắt buộc phải có để tra tên từ mã)
            string catRes = await SocketClient.SendRequestAsync("GET_ALL_CATEGORY");
            if (!catRes.StartsWith("ERROR"))
            {
                categoryList = JsonConvert.DeserializeObject<List<CafeCommon.LoaiMon>>(catRes);
            }

            // 2. Tải Menu
            string res = await SocketClient.SendRequestAsync("GET_ALL_MENU");
            if (!res.StartsWith("ERROR"))
            {
                var list = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(res);

                if (dgvFood.Columns.Contains("colMoTa"))
                {
                    dgvFood.Columns["colMoTa"].DataPropertyName = "MoTa"; // Khớp với model
                }

                if (dgvFood.Columns.Contains("colLoaiMon"))
                {
                    var gridCol = (DataGridViewComboBoxColumn)dgvFood.Columns["colLoaiMon"];
                    gridCol.DataSource = categoryList;
                    gridCol.DisplayMember = "TenLoai";  // Hiện chữ
                    gridCol.ValueMember = "MaLoaiMon";   // Khớp với số ID
                    gridCol.DataPropertyName = "MaLoaiMon"; // Lấy từ MaLoaiMon của class Menu
                    gridCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // Hiện như text bình thường
                }

                dgvFood.AutoGenerateColumns = false;
                dgvFood.DataSource = list;

                if (list != null && list.Count > 0) FillMenuToFields(list[0]);
            }
        }

        private void FillMenuToFields(CafeCommon.Menu item)
        {
            tbMaMon.Text = item.MaMon.ToString();
            tbTenMon.Text = item.TenMon ?? "";
            nmGiaBan.Value = Convert.ToDecimal(item.Gia);
            txtMoTa.Text = item.MoTa ?? "";

            var loai = categoryList.FirstOrDefault(x => x.MaLoaiMon == item.MaLoaiMon);
            tbTenLoaiMon.Text = loai?.TenLoai ?? "Không xác định";

            cbTrangThai.Text = item.TrangThai ?? "";
            selectedMenuId = item.MaMon;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTenMon.Text))
            {
                MessageBox.Show("Hãy nhập tên món ăn!");
                return;
            }

            // Dịch ngược từ Tên loại (TextBox) sang Mã loại (ID)
            var loai = categoryList.FirstOrDefault(x => x.TenLoai.Equals(tbTenLoaiMon.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (loai == null)
            {
                MessageBox.Show("Tên loại món không hợp lệ hoặc không tồn tại trong hệ thống!");
                return;
            }

            //  Gửi mã số (loai.MaLoaiMon) qua Socket
            string cmd = $"ADD_MENU|{loai.MaLoaiMon}|{tbTenMon.Text}|{txtMoTa.Text}|{nmGiaBan.Value}|{cbTrangThai.Text}";
            string res = await SocketClient.SendRequestAsync(cmd);

            if (res == "SUCCESS")
            {
                MessageBox.Show("Thêm món thành công!");
                await LoadMenuData();
                tbTenMon.Clear();
                tbTenMon.Focus();
            }
            else
            {
                MessageBox.Show("Lỗi: " + res);
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
                MessageBox.Show("Vui lòng chọn món để sửa!");
                return;
            }

            // Tìm ID loại món từ tên trong TextBox
            var loai = categoryList.FirstOrDefault(x => x.TenLoai.Equals(tbTenLoaiMon.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (loai == null)
            {
                MessageBox.Show("Loại món không hợp lệ!");
                return;
            }

            // Gói tin: UPDATE_MENU|MaMon|MaLoaiMon|TenMon|MoTa|Gia|TrangThai
            string cmd = $"UPDATE_MENU|{selectedMenuId}|{loai.MaLoaiMon}|{tbTenMon.Text}|{txtMoTa.Text}|{nmGiaBan.Value}|{cbTrangThai.Text}";

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

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
