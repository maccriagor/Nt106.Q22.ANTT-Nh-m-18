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
        private List<HoaDon> fullBillList = new List<HoaDon>();
        public HoaDon_AD()
        {
            InitializeComponent();
        }

        private async Task LoadBills()
        {
            string response = await SocketClient.SendRequestAsync("GET_BILLS");
            if (response.Contains("SUCCESS"))
            {
                string json = response.Split('|')[1];
                fullBillList = JsonConvert.DeserializeObject<List<HoaDon>>(json);

                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = fullBillList;

                // Ẩn các cột không cần thiết
                string[] hiddenCols = { "MaDonHang", "MaKH", "PhuongThucThanhToan", "GhiChu", "BaseUrl", "RequestClient", "TableName", "PrimaryKey", "RequestClientOptions" };
                foreach (var col in hiddenCols)
                    if (dgvHoaDon.Columns.Contains(col)) dgvHoaDon.Columns[col].Visible = false;

                // Định dạng tiền tệ và tiêu đề
                if (dgvHoaDon.Columns.Contains("TongTien")) dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                if (dgvHoaDon.Columns.Contains("ThanhTien")) dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HD";
                dgvHoaDon.Columns["MaBanAn"].HeaderText = "Bàn";
                dgvHoaDon.Columns["MaNV"].HeaderText = "Nhân Viên";
                dgvHoaDon.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            }
        }

        private void ClearFields()
        {
            txtMaHoaDon.Clear();
            txtMaNhanVien.Clear();
            txtMaBanAn.Clear();
            txtNgayXuatHD.Clear();
            tbTimKiem.Clear();
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            await LoadBills();
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            await LoadBills();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = tbTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                dgvHoaDon.DataSource = fullBillList;
                return;
            }

            // Tìm theo Mã hóa đơn hoặc Mã bàn ăn
            var filtered = fullBillList.Where(x =>
                x.MaHD.ToString() == key ||
                (x.MaBanAn.HasValue && x.MaBanAn.Value.ToString() == key)
            ).ToList();

            dgvHoaDon.DataSource = filtered;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["MaHD"].Value?.ToString();
                txtMaNhanVien.Text = row.Cells["MaNV"].Value?.ToString();
                txtMaBanAn.Text = row.Cells["MaBanAn"].Value?.ToString() ?? "Mang về";
                txtNgayXuatHD.Text = Convert.ToDateTime(row.Cells["NgayTao"].Value).ToString("dd/MM/yyyy HH:mm");
            }
        }
    }
}
