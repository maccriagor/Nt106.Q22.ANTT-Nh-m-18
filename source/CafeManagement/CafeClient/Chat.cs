using CafeCommon;
using CafeServer;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using Org.BouncyCastle.Tls;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DrawingColor = System.Drawing.Color;
using DrawingFont = System.Drawing.Font;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;

namespace CafeClient
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            this.Load += ChatForm_Load;
            this.Load += async (s, e) =>
            {
                await LoadDanhSachNguoiDung();
            };


            SocketClient.OnMessageReceived += HandleIncomingSocketMessage;

            this.FormClosed += (s, e) => SocketClient.OnMessageReceived -= HandleIncomingSocketMessage;
        }

        private void HandleIncomingSocketMessage(string rawMessage)
        {
            if (!rawMessage.StartsWith("NEW_MESSAGE|")) return;

            string json = rawMessage.Substring("NEW_MESSAGE|".Length);
            try
            {
                var msg = JsonConvert.DeserializeObject<TinNhan>(json);
                if (msg != null) OnMessageReceived(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Chat] Failed to parse incoming message: {ex.Message}");
            }
        }

        private List<UserAccount> allEmployees = new List<UserAccount>();
        private void ChatForm_Load(object sender, EventArgs e)
        {

            lbRole.Text += " " + UserSession.VaiTro;


        }
        private static DateTime _lastDisplayDate = DateTime.MinValue;
        private Dictionary<int, string> _chatHistories = new Dictionary<int, string>();
        private string GetUserNameById(int id)
        {
            // Tìm trong danh sách toàn bộ nhân viên đã load vào app
            var user = allEmployees.FirstOrDefault(u => u.MaNguoiDung == id);
            return user != null ? user.HoTen : "Unknown";
        }

        private void HienThiTinNhan(TinNhan msg)
        {
            if (msg.Timestamp.Date != _lastDisplayDate.Date)
            {
                rtbChat.SelectionAlignment = HorizontalAlignment.Center;
                rtbChat.SelectionFont = new DrawingFont("Segoe UI", 8, FontStyle.Bold);
                rtbChat.SelectionColor = DrawingColor.Gray;
                rtbChat.AppendText($"\n--- {msg.Timestamp:dd/MM/yyyy} ---\n\n");
                _lastDisplayDate = msg.Timestamp.Date;
            }
            string senderName = (msg.SenderId == UserSession.MaNguoiDung)
        ? "Tôi"
        : (allEmployees.FirstOrDefault(u => u.MaNguoiDung == msg.SenderId)?.HoTen ?? "Khách");

            // 2. Logic căn lề và màu sắc
            bool isMyMessage = msg.SenderId == UserSession.MaNguoiDung;
            rtbChat.SelectionAlignment = isMyMessage ? HorizontalAlignment.Right : HorizontalAlignment.Left;

            // 3. Tên và Giờ
            rtbChat.SelectionFont = new DrawingFont("Segoe UI", 8, FontStyle.Bold);
            rtbChat.SelectionColor = isMyMessage ? DrawingColor.DodgerBlue : DrawingColor.DarkSlateGray;
            rtbChat.AppendText($"{senderName} ");

            rtbChat.SelectionFont = new DrawingFont("Segoe UI", 7, FontStyle.Italic);
            rtbChat.AppendText($"{msg.Timestamp:HH:mm}\n");

            // 4. Nội dung
            rtbChat.SelectionAlignment = isMyMessage ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            rtbChat.SelectionFont = new DrawingFont("Segoe UI", 10, FontStyle.Regular);
            rtbChat.SelectionColor = DrawingColor.Black;
            rtbChat.AppendText($"{msg.Content}\n\n");

            rtbChat.ScrollToCaret();
        }


        private async Task LoadDanhSachNguoiDung()
        {
            string response = await SocketClient.SendRequestAsync("GET_CHAT_USERS");
            string[] parts = response.Split('|');

            if (parts[0] == "SUCCESS")
            {
                allEmployees = JsonConvert.DeserializeObject<List<UserAccount>>(parts[1]);
                var listUser = JsonConvert.DeserializeObject<List<UserAccount>>(parts[1]);

                lvNhanVien.Items.Clear();
                lvNhanVien.BeginUpdate(); // Tối ưu: Ngừng vẽ khi đang thêm hàng loạt

                foreach (var user in listUser)
                {
                    if (user.HoTen == UserSession.HoTen) continue;

                    // 1. Tạo item (Cột 0: Tên đăng nhập)
                    ListViewItem item = new ListViewItem(user.HoTen);
                    item.ImageIndex = user.TrangThaiOnline ? 0 : 1;

                    // 2. Thêm SubItem (Cột 1: Vai trò)
                    ListViewItem.ListViewSubItem roleSubItem = new ListViewItem.ListViewSubItem(item, user.VaiTro);
                    item.SubItems.Add(roleSubItem);

                    // 3. Đổi màu chữ dựa trên vai trò
                    switch (user.VaiTro.ToLower())
                    {
                        case "Kitchen":
                            roleSubItem.ForeColor = DrawingColor.Gold;
                            break;
                        case "Waiter":
                            roleSubItem.ForeColor = DrawingColor.DodgerBlue;
                            break;
                        case "Admin":
                            roleSubItem.ForeColor = DrawingColor.Red;
                            break;
                        default:
                            roleSubItem.ForeColor = DrawingColor.Black;
                            break;
                    }

                    item.Tag = user;
                    lvNhanVien.Items.Add(item);
                }

                lvNhanVien.EndUpdate(); // Vẽ lại sau khi xong
            }
            else
            {
                MessageBox.Show("Lỗi: " + parts[1]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.Clear(); // Xóa sạch nội dung hiện tại
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi trực tiếp hàm xử lý của nút tìm kiếm
                btnTimKiem.PerformClick();

                // Ngăn chặn tiếng "bíp" mặc định của Windows khi nhấn Enter trong TextBox
                e.SuppressKeyPress = true;
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            // Gửi yêu cầu tìm kiếm kèm keyword
            string response = await SocketClient.SendRequestAsync($"SEARCH_USER|{keyword}");
            string[] parts = response.Split('|');

            if (parts[0] == "SUCCESS")
            {
                var listUser = JsonConvert.DeserializeObject<List<UserAccount>>(parts[1]);

                // Cập nhật lại ListView với danh sách đã lọc
                lvNhanVien.Items.Clear();
                foreach (var user in listUser)
                {
                    if (user.HoTen == UserSession.HoTen) continue;

                    ListViewItem item = new ListViewItem(user.HoTen);
                    item.ImageIndex = user.TrangThaiOnline ? 0 : 1;
                    item.Tag = user;
                    lvNhanVien.Items.Add(item);
                }
            }
        }
        private UserAccount selectedRecipient = null; // Biến lưu người nhận hiện tại
        private async void LoadLichSuTuDatabase(int friendId)
        {

            await DatabaseService.InitializeAsync();

            var response = await DatabaseService.Client.From<TinNhan>()
                .Where(m => m.SenderId == UserSession.MaNguoiDung)
                .Get();

            var response2 = await DatabaseService.Client.From<TinNhan>()
                .Where(m => m.RecipientId == UserSession.MaNguoiDung)
                .Get();

            var response3 = await DatabaseService.Client.From<TinNhan>()
                .Where(m => m.RecipientId == null)
                .Get();
            Console.WriteLine($"[DEBUG] response3 (RecipientId == null) returned {response3.Models.Count} rows");
            foreach (var m in response3.Models)
            {
                Console.WriteLine($"[DEBUG]   -> MaTinNhan={m.MaTinNhan}, SenderId={m.SenderId}, RecipientId={(m.RecipientId.HasValue ? m.RecipientId.Value.ToString() : "NULL")}");
            }

            var allMessages = response.Models
                .Concat(response2.Models)
                .Concat(response3.Models)
                .GroupBy(m => m.MaTinNhan)
                .Select(g => g.First())
                .ToList();

            var filteredMessages = allMessages
                .Where(m => (m.SenderId == UserSession.MaNguoiDung && m.RecipientId == friendId) ||
                            (m.SenderId == friendId && m.RecipientId == UserSession.MaNguoiDung) ||
                            (m.RecipientId == null && m.SenderId != UserSession.MaNguoiDung))
                .OrderBy(m => m.Timestamp)
                .ToList();

            rtbChat.Clear();
            foreach (var msg in filteredMessages)
            {
                HienThiTinNhan(msg);
            }
        }
        private void lvNhanVien_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                selectedRecipient = (UserAccount)lvNhanVien.SelectedItems[0].Tag;
                lbUserName.Text = $"Đang chat với: {selectedRecipient.HoTen}";

                rtbChat.Clear();
                LoadLichSuTuDatabase(selectedRecipient.MaNguoiDung);
            }
        }

        private void OnMessageReceived(TinNhan msg)
        {
            bool isMyRecipient = (selectedRecipient != null &&
        ((msg.SenderId == selectedRecipient.MaNguoiDung) || (msg.RecipientId == selectedRecipient.MaNguoiDung)));
            bool isBroadcast = (msg.RecipientId == null);

            if (isMyRecipient || isBroadcast)
            {
                this.Invoke(new Action(() =>
                {
                    HienThiTinNhan(msg);
                }));
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)

        {
            string noiDung = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(noiDung)) return;

            // 1. Tạo đối tượng
            TinNhan message = new TinNhan
            {
                SenderId = UserSession.MaNguoiDung,
                RecipientId = cbEveryone.Checked ? null : (int?)selectedRecipient?.MaNguoiDung,
                Content = noiDung,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            // 2. Logic kiểm tra
            if (!cbEveryone.Checked && selectedRecipient == null)
            {
                MessageBox.Show("Vui lòng chọn người nhận!");
                return;
            }

            // 3. XỬ LÝ CHUỖI GỬI: Thay vì để null làm hỏng chuỗi, dùng "null" hoặc "0"
            string recipientStr = message.RecipientId.HasValue ? message.RecipientId.ToString() : "null";
            string jsonMessage = JsonConvert.SerializeObject(message);

            // Gửi đúng định dạng: SEND_MESSAGE|null|{...} hoặc SEND_MESSAGE|28|{...}
            string payload = $"SEND_MESSAGE|{recipientStr}|{jsonMessage}";
            string response = await SocketClient.SendRequestAsync(payload);

            // 4. Phản hồi
            if (response.StartsWith("SUCCESS"))
            {
                HienThiTinNhan(message);
                txtMessage.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + response);
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnLamMoi.Enabled = false;
            try
            {
                // 1. Tải lại danh sách nhân viên (cập nhật trạng thái online/offline, nhân viên mới...)
                await LoadDanhSachNguoiDung();

                // 2. Nếu đang mở một cuộc trò chuyện, tải lại lịch sử tin nhắn của cuộc trò chuyện đó
                if (selectedRecipient != null)
                {
                    rtbChat.Clear();
                    LoadLichSuTuDatabase(selectedRecipient.MaNguoiDung);
                }
            }
            finally
            {
                btnLamMoi.Enabled = true;
            }
        }
    }
}
