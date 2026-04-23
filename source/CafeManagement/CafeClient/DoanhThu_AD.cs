using CafeCommon;
using ClosedXML;
using ClosedXML.Excel;
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
    public partial class DoanhThu_AD : Form
    {
        public DoanhThu_AD()
        {
            InitializeComponent();
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            string fromDate = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string toDate = dtpDenNgay.Value.ToString("yyyy-MM-dd");

            string request = $"GET_REVENUE|{fromDate}|{toDate}";
            string response = await SocketClient.SendRequestAsync(request);

            if (response.StartsWith("REVENUE_SUCCESS"))
            {
                string jsonData = response.Split('|')[1];
                var list = JsonConvert.DeserializeObject<List<RevenueByTableDTO>>(jsonData);

                // đưa vào DataGridView
                dgvDoanhThu.DataSource = list;

                // Tính tổng doanh thu hiện lên Label dưới cùng
                decimal total = list.Sum(x => x.DoanhThu);
                lbTongDoanhThu.Text = total.ToString("N0") + " VND";
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu để xuất không
            if (dgvDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo");
                return;
            }

            // Cấu hình mess box lưu file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Doanh Thu");

                            // Tạo Tiêu đề các cột (Header)
                            for (int i = 0; i < dgvDoanhThu.Columns.Count; i++)
                            {
                                // Chỉ lấy những cột đang hiển thị
                                if (dgvDoanhThu.Columns[i].Visible)
                                {
                                    worksheet.Cell(1, i + 1).Value = dgvDoanhThu.Columns[i].HeaderText;
                                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#804000"); // Màu nâu của bạn
                                    worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                                }
                            }

                            // 4. Đưa dữ liệu từ GridView vào các dòng
                            for (int r = 0; r < dgvDoanhThu.Rows.Count; r++)
                            {
                                for (int c = 0; c < dgvDoanhThu.Columns.Count; c++)
                                {
                                    if (dgvDoanhThu.Columns[c].Visible)
                                    {
                                        worksheet.Cell(r + 2, c + 1).Value = dgvDoanhThu.Rows[r].Cells[c].Value?.ToString();
                                    }
                                }
                            }

                            // Thêm dòng Tổng doanh thu ở cuối
                            int lastRow = dgvDoanhThu.Rows.Count + 3;
                            worksheet.Cell(lastRow, 1).Value = "TỔNG DOANH THU:";
                            worksheet.Cell(lastRow, 1).Style.Font.Bold = true;
                            worksheet.Cell(lastRow, 2).Value = lbTongDoanhThu.Text;
                            worksheet.Cell(lastRow, 2).Style.Font.FontColor = XLColor.Red;

                            // Tự động căn chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();

                            // Lưu file
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
                    }
                }
        }
    }
    }
}
