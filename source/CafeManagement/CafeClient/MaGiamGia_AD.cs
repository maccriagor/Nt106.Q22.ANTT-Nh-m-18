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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CafeClient
{
    public partial class MaGiamGia_AD : Form
    {
        private List<KhuyenMaiDTO> fullListDiscount = new List<KhuyenMaiDTO>();
        public MaGiamGia_AD()
        {
            InitializeComponent();
        }


        private async Task LoadDiscounts()
        {
            string response = await SocketClient.SendRequestAsync("GET_DISCOUNTS");
            if (response.StartsWith("SUCCESS"))
            {
                string json = response.Split('|')[1];
                fullListDiscount = JsonConvert.DeserializeObject<List<KhuyenMaiDTO>>(json);
                dgvMaGiamGia.DataSource = fullListDiscount;
            }
        }

        private bool ValidateInput()
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tbCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã Code!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbLoaiKhuynMai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra định dạng số cho Giá trị giảm
            if (!decimal.TryParse(tbGiaTriGiam.Text, out decimal giaTri) || giaTri <= 0)
            {
                MessageBox.Show("Giá trị giảm phải là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Kiểm tra ngày tháng logic
            if (dtpNgayBatDau.Value.Date > dtpNgayKetThuc.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            tbMaKhuyenMai.Clear();
            tbMaKhuyenMai.Tag = null;
            tbCode.Clear();
            tbGiaTriGiam.Clear();
            txtMoTa.Clear();
            cbLoaiKhuynMai.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            txtTim.Clear(); // Xóa ô tìm kiếm
            await LoadDiscounts(); // Gọi lại hàm nạp dữ liệu
        }

        private void dgvMaGiamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMaGiamGia.Rows[e.RowIndex];

                // Gán vào Tag của Form hoặc một biến ẩn để biết đang chọn MaKM nào
                tbMaKhuyenMai.Text = row.Cells["MaKM"].Value?.ToString();
                tbMaKhuyenMai.Tag = row.Cells["MaKM"].Value;

                tbCode.Text = row.Cells["CodeKM"].Value?.ToString();
                cbLoaiKhuynMai.SelectedItem = row.Cells["LoaiKM"].Value?.ToString();
                tbGiaTriGiam.Text = row.Cells["GiaTriGiam"].Value?.ToString();
                dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (tbMaKhuyenMai.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một mã từ danh sách để sửa!", "Thông báo");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
                bool trangThaiMoi = true; // Mặc định là True

                // KIỂM TRA NẾU ADMIN ĐỔI NGÀY VỀ QUÁ KHỨ
                if (ngayKetThuc < DateTime.Now.Date)
                {
                    var confirm = MessageBox.Show(
                        "Bạn đang chỉnh sửa ngày kết thúc về quá khứ. Hệ thống sẽ tự động chuyển trạng thái mã này thành 'Ngừng hoạt động' (False). Bạn có đồng ý?",
                        "Xác nhận thay đổi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.No) return; // Hủy thao tác sửa nếu user không đồng ý

                    trangThaiMoi = false; // Ép trạng thái về False
                }

                var km = new KhuyenMai
                {
                    MaKM = (int)tbMaKhuyenMai.Tag,
                    CodeKM = tbCode.Text.Trim(),
                    LoaiKM = cbLoaiKhuynMai.SelectedItem.ToString(),
                    GiaTriGiam = decimal.Parse(tbGiaTriGiam.Text),
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayHetHan = dtpNgayKetThuc.Value,
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = trangThaiMoi // Gán trạng thái mới sau khi kiểm tra
                };

                string request = "UPDATE_DISCOUNT|" + JsonConvert.SerializeObject(km);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Cập nhật mã giảm giá thành công!", "Thành công");
                    await LoadDiscounts();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + (res.Contains("|") ? res.Split('|')[1] : "Không xác định"), "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (tbMaKhuyenMai.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn mã cần xóa!", "Thông báo");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa mã này?", "Xác nhận xóa",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string request = "DELETE_DISCOUNT|" + tbMaKhuyenMai.Tag.ToString();
                    string res = await SocketClient.SendRequestAsync(request);

                    if (res.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDiscounts();
                        ClearFields(); //Xoa trang
                    }
                    else
                    {
                        string errorMsg = res.Contains("|") ? res.Split('|')[1] : "Lỗi không xác định";
                        MessageBox.Show("Xóa thất bại: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi yêu cầu xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // 1. Khởi tạo trạng thái mặc định là True
                bool statusToAdd = true;

                // 2. Kiểm tra nếu ngày kết thúc nhỏ hơn thời điểm hiện tại
                if (dtpNgayKetThuc.Value < DateTime.Now)
                {
                    DialogResult result = MessageBox.Show(
                        "Mã giảm giá này đã hết hạn so với ngày hiện tại. Hệ thống sẽ tự động chuyển trạng thái sang 'Ngừng hoạt động' (False). Bạn vẫn muốn thêm?",
                        "Cảnh báo hết hạn",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return; // Dừng việc thêm nếu người dùng chọn No
                    }

                    // Nếu chọn Yes, thiết lập trạng thái là False
                    statusToAdd = false;
                }

                // 3. Tạo đối tượng KhuyenMai với trạng thái đã xác định
                var km = new KhuyenMai
                {
                    CodeKM = tbCode.Text.Trim(),
                    LoaiKM = cbLoaiKhuynMai.SelectedItem.ToString(),
                    GiaTriGiam = decimal.Parse(tbGiaTriGiam.Text),
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayHetHan = dtpNgayKetThuc.Value,
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = statusToAdd // Gán trạng thái False nếu mã đã hết hạn
                };

                string request = "ADD_DISCOUNT|" + JsonConvert.SerializeObject(km);
                string res = await SocketClient.SendRequestAsync(request);

                if (res.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Thêm mã giảm giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // Hàm xóa trắng các ô nhập liệu
                    await LoadDiscounts();
                }
                else
                {
                    string errorMsg = res.Contains("|") ? res.Split('|')[1] : "Lỗi không xác định";
                    MessageBox.Show("Thêm thất bại: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvMaGiamGia.DataSource = fullListDiscount; // Nếu ô trống thì hiện hết
                return;
            }

            // Lọc theo CodeKM hoặc Mô tả bằng LINQ
            var filteredList = fullListDiscount.Where(x =>
                (x.CodeKM != null && x.CodeKM.ToLower().Contains(keyword)) ||
                (x.MoTa != null && x.MoTa.ToLower().Contains(keyword))
            ).ToList();

            dgvMaGiamGia.DataSource = filteredList;
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
