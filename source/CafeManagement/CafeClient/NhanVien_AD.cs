using CafeCommon;
using Newtonsoft.Json;
using System;
using System.Collections;
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

    public partial class NhanVien_AD : Form
    {
        private int selectedUserId = 0; //id của người đang được chọn

        public NhanVien_AD()
        {
            InitializeComponent();
        }
        //Hàm up danh sách nhân viên
        private async Task LoadEmployees()
        {
            string res = await SocketClient.SendRequestAsync("GET_ALL_EMPLOYEES");

            if (!res.StartsWith("ERROR"))
            {
                var list = JsonConvert.DeserializeObject<List<UserAccount>>(res);

                dgvNhanVien.AutoGenerateColumns = false;
                dgvNhanVien.DataSource = list;

                if (list != null && list.Count > 0)
                {
                    var firstEmp = list[0];

                    txtUserName.Text = firstEmp.TenDangNhap ?? "";
                    tbTenNhanVien.Text = firstEmp.HoTen ?? "";
                    tbEmail.Text = firstEmp.Email ?? "";
                    tbVaiTro.Text = firstEmp.VaiTro ?? "";
                    tbPass.Text = "";

                    if (firstEmp.NgayTao.HasValue && firstEmp.NgayTao.Value.Year > 1753)
                    {
                        dtpNgayVaoLam.Value = firstEmp.NgayTao.Value;
                    }
                    else
                    {
                        // Nếu là null hoặc ngày 0001 từ dữ liệu cũ, để mặc định là hôm nay
                        dtpNgayVaoLam.Value = DateTime.Now;
                    }

                    selectedUserId = firstEmp.MaNguoiDung;
                }
            }
            else
            {
                MessageBox.Show("Lỗi: " + res);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu để trống ô tìm kiếm thì load lại toàn bộ danh sách
                await LoadEmployees();
                return;
            }

            // Gửi yêu cầu tìm kiếm
            string res = await SocketClient.SendRequestAsync($"SEARCH_EMPLOYEE|{keyword}");

            if (!res.StartsWith("ERROR"))
            {
                // Giải mã danh sách kết quả và hiển thị lên Grid
                var searchResult = JsonConvert.DeserializeObject<List<UserAccount>>(res);
                dgvNhanVien.DataSource = searchResult;

                if (searchResult.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào khớp với tên này!");
                }
            }
        }
        //Hàm load danh sách nhân viên
        private async void btnXem_Click(object sender, EventArgs e)
        {
            await LoadEmployees();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            //  Kiểm tra nhanh ở Client
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(tbPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!");
                return;
            }

            // Gửi lệnh REGISTER
            string cmd = $"REGISTER|{txtUserName.Text}|{tbPass.Text}|{tbEmail.Text}||{tbTenNhanVien.Text}|{tbVaiTro.Text}";
            string res = await SocketClient.SendRequestAsync(cmd);

            // 2. Xử lý phản hồi
            if (res.StartsWith("REGISTER_SUCCESS"))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadEmployees();
                txtUserName.Clear();
                tbPass.Clear();
            }
            else if (res.StartsWith("REGISTER_FAIL"))
            {
                // Tách chuỗi để lấy thông báo lỗi sau dấu gạch đứng |
                string errorMessage = res.Split('|')[1];

                MessageBox.Show(errorMessage, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Focus();
                txtUserName.SelectAll();
            }
            else
            {
                // Trường hợp lỗi khác (ví dụ: ERROR|Mất kết nối server)
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + res);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên nào chưa
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để xóa!");
                return;
            }
            // Gói tin: UPDATE_EMPLOYEE|id|user|name|email|pass|role
            string cmd = $"UPDATE_EMPLOYEE|{selectedUserId}|{txtUserName.Text}|{tbTenNhanVien.Text}|{tbEmail.Text}|{tbPass.Text}|{tbVaiTro.Text}";
            string res = await SocketClient.SendRequestAsync(cmd);

            if (res == "SUCCESS")
            {
                MessageBox.Show("Cập nhật thành công!");
                await LoadEmployees();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên nào chưa
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để xóa!");
                return;
            }

            // Xác nhận xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Gửi lệnh xóa qua Socket
                string res = await SocketClient.SendRequestAsync($"DELETE_EMPLOYEE|{selectedUserId}");

                if (res == "SUCCESS")
                {
                    MessageBox.Show("Xóa nhân viên thành công!");
                    selectedUserId = 0; // Reset ID về 0 sau khi xóa
                    await LoadEmployees(); // Tải lại danh sách để cập nhật UI
                }
                else
                {
                    MessageBox.Show("Xóa thất bại: " + res);
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];

                // Thêm ?.ToString() ?? "" để bảo vệ code không bị văng
                txtUserName.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                tbTenNhanVien.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                tbEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                tbVaiTro.Text = row.Cells["VaiTro"].Value?.ToString() ?? "";


                if (row.Cells["NgayTao"].Value != null &&
                    DateTime.TryParse(row.Cells["NgayTao"].Value.ToString(), out DateTime dtCheck))
                {
                    // DateTimePicker chỉ nhận ngày từ năm 1753 trở đi
                    dtpNgayVaoLam.Value = (dtCheck.Year > 1753) ? dtCheck : DateTime.Now;
                }
                else
                {
                    dtpNgayVaoLam.Value = DateTime.Now;
                }

                if (row.Cells["MaNguoiDung"].Value != null)
                {
                    selectedUserId = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                }
            }
        }
        
    }
}
