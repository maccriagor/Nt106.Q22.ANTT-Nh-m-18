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
    public partial class BanAn_AD : Form
    {
        private List<BanAn> fullTableList = new List<BanAn>();
        public BanAn_AD()
        {
            InitializeComponent();
        }

        private async void BanAn_AD_Load(object sender, EventArgs e)
        {
            await LoadTables();
        }

        private async Task LoadTables()
        {
            string response = await SocketClient.SendRequestAsync("GET_TABLES");
            if (response.StartsWith("SUCCESS"))
            {
                string json = response.Split('|')[1];
                fullTableList = JsonConvert.DeserializeObject<List<BanAn>>(json);
                dgvBanAn.DataSource = null;
                dgvBanAn.DataSource = fullTableList;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tbTenBan.Text))
            {
                MessageBox.Show("Tên bàn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numSoChoNgoi.Value <= 0)
            {
                MessageBox.Show("Số chỗ ngồi phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            tbMaBan.Clear();
            tbMaBan.Tag = null; // Quan trọng để nhận biết trạng thái đang chọn
            tbTenBan.Clear();
            numSoChoNgoi.Value = 2; // Giá trị mặc định phổ biến
            cbTrangThai.SelectedIndex = -1;
            dtpNgayTao.Value = DateTime.Now;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var ban = new BanAn
                {
                    TenBan = tbTenBan.Text.Trim(),
                    SoChoNgoi = (int)numSoChoNgoi.Value,
                    TrangThai = "Trống", // Bàn mới tạo luôn ở trạng thái Trống
                    NgayTao = DateTime.Now
                };

                string request = "ADD_TABLE|" + JsonConvert.SerializeObject(ban);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Thêm bàn mới thành công!", "Thành công");
                    ClearFields();
                    await LoadTables();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + res.Split('|')[1], "Thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (tbMaBan.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Thông báo");
                return;
            }

            // Ràng buộc tại Client: Cảnh báo nếu bàn không trống (Server cũng sẽ check lại)
            if (cbTrangThai.Text != "Trống")
            {
                MessageBox.Show("Chỉ được phép xóa bàn đang ở trạng thái 'Trống'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int id = (int)tbMaBan.Tag;
                    string res = await SocketClient.SendRequestAsync($"DELETE_TABLE|{id}");

                    if (res.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Xóa bàn thành công!", "Thông báo");
                        await LoadTables();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại: " + res.Split('|')[1], "Lỗi");
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
            if (tbMaBan.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn từ danh sách để sửa!", "Thông báo");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var ban = new BanAn
                {
                    MaBanAn = (int)tbMaBan.Tag,
                    TenBan = tbTenBan.Text.Trim(),
                    SoChoNgoi = (int)numSoChoNgoi.Value
                    // Lưu ý: Không gửi trạng thái để tránh Admin can thiệp vận hành
                };

                string request = "UPDATE_TABLE|" + JsonConvert.SerializeObject(ban);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Cập nhật thông tin bàn thành công!", "Thành công");
                    await LoadTables();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + res.Split('|')[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi sửa: " + ex.Message);
            }
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            tbTimKiem.Clear();
            await LoadTables();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = tbTimKiem.Text.ToLower().Trim();
            string statusFilter = cbTrangThai.Text; // Trống, Có khách, Đã đặt

            var filtered = fullTableList.Where(x =>
                (x.TenBan.ToLower().Contains(key)) &&
                (statusFilter == "Tất cả" || string.IsNullOrEmpty(statusFilter) || x.TrangThai == statusFilter)
            ).ToList();

            dgvBanAn.DataSource = null;
            dgvBanAn.DataSource = filtered;
        }

        private void dgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBanAn.Rows[e.RowIndex];
                tbMaBan.Text = row.Cells["MaBanAn"].Value.ToString();
                tbTenBan.Text = row.Cells["TenBan"].Value.ToString();
                numSoChoNgoi.Value = Convert.ToInt32(row.Cells["SoChoNgoi"].Value);
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            }
        }
    }
}
