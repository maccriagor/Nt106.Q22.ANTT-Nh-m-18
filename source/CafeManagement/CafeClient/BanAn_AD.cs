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
            
        }

        private async Task LoadTables()
        {
            string response = await SocketClient.SendRequestAsync("GET_TABLES");
            if (response.Contains("SUCCESS"))
            {
                string json = response.Split('|')[1];
                fullTableList = JsonConvert.DeserializeObject<List<BanAn>>(json);

                dgvBanAn.DataSource = null;
                dgvBanAn.DataSource = fullTableList;

                // ẨN CÁC CỘT THỪA CỦA BASEMODEL
                string[] hiddenCols = { "BaseUrl", "RequestClient", "TableName", "PrimaryKey", "RequestClientOptions" };
                foreach (var colName in hiddenCols)
                {
                    if (dgvBanAn.Columns.Contains(colName))
                        dgvBanAn.Columns[colName].Visible = false;
                }
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
            tbMaBan.Tag = null;
            tbTenBan.Clear();
            numSoChoNgoi.Value = 1;
            cbTrangThai.SelectedIndex = -1; // Reset combobox
            dtpNgayTao.Value = DateTime.Now;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var ban = new BanAn
                {
                    // Không gán MaBanAn vì Database tự tăng
                    TenBan = tbTenBan.Text.Trim(),
                    SoChoNgoi = (int)numSoChoNgoi.Value,
                    TrangThai = "Trống", // Mặc định luôn là Trống khi thêm mới
                    MaNhanVien = null,     
                    NgayTao = dtpNgayTao.Value // Lấy theo ngày người dùng chọn ở DateTimePicker
                };

                string request = "ADD_TABLE|" + JsonConvert.SerializeObject(ban);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                    ClearFields();
                    await LoadTables();
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

                    if (res.Contains("SUCCESS"))
                    {
                        MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                        ClearFields();
                        await LoadTables();
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
            if (tbMaBan.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn từ danh sách!");
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
                    // TUYỆT ĐỐI không gán TrangThai ở đây để tránh thay đổi trạng thái vận hành
                };

                string request = "UPDATE_TABLE|" + JsonConvert.SerializeObject(ban);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show(res.Split('|')[1], "Thành công"); // Lấy nội dung từ Server gửi về
                    ClearFields();
                    await LoadTables();
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

        private async void btnXem_Click(object sender, EventArgs e)
        {
            tbTimKiem.Clear();
            await LoadTables();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = tbTimKiem.Text.ToLower().Trim();
            string statusFilter = cbTrangThai.Text;

            // Logic tìm kiếm linh hoạt: Nếu không chọn trạng thái thì tìm theo tên
            var filtered = fullTableList.Where(x =>
                (x.TenBan.ToLower().Contains(key)) &&
                (statusFilter == "" || statusFilter == "Tất cả" || x.TrangThai == statusFilter)
            ).ToList();

            dgvBanAn.DataSource = null;
            dgvBanAn.DataSource = filtered;

            // Đừng quên ẩn cột lại sau khi gán DataSource mới
            string[] hiddenCols = { "BaseUrl", "RequestClient", "TableName", "PrimaryKey", "RequestClientOptions" };
            foreach (var colName in hiddenCols)
                if (dgvBanAn.Columns.Contains(colName)) dgvBanAn.Columns[colName].Visible = false;
        }

        private void dgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBanAn.Rows[e.RowIndex];

                // Gán MaBanAn vào cả Text (để xem) và Tag (để xử lý code)
                tbMaBan.Text = row.Cells["MaBanAn"].Value.ToString();
                tbMaBan.Tag = row.Cells["MaBanAn"].Value;

                tbTenBan.Text = row.Cells["TenBan"].Value?.ToString();
                numSoChoNgoi.Value = Convert.ToInt32(row.Cells["SoChoNgoi"].Value);
                cbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();

                if (row.Cells["NgayTao"].Value != null)
                    dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            }
        }
    }
}
