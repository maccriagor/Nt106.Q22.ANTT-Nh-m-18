using CafeCommon;
using CafeServer.Services;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Configuration;

namespace CafeServer
{
    public class SocketServer
    {
        private static ConcurrentDictionary<int, NetworkStream> _activeClients = new ConcurrentDictionary<int, NetworkStream>();
        private TcpListener _listener;
        private int _port = 8888;
        private bool _isRunning;

        // Danh sách này lưu các Stream của tất cả Client đang mở App
        private static List<NetworkStream> _activeStreams = new List<NetworkStream>();

        //Dọn dẹp OTP khi xong việc --> tránh bị sử dụng lại
        public static System.Collections.Concurrent.ConcurrentDictionary<string, string> OtpStorage =
    new System.Collections.Concurrent.ConcurrentDictionary<string, string>();

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            _isRunning = true;
            Console.WriteLine($"[SERVER] Đang lắng nghe tại cổng {_port}...");

            // Vòng lặp chấp nhận kết nối từ các máy khách
            Task.Run(async () =>
            {
                while (_isRunning)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    Console.WriteLine($"[SERVER] Một Client mới đã kết nối: {client.Client.RemoteEndPoint}");

                    // Tạo một luồng riêng để xử lý mỗi Client
                    _ = Task.Run(() => HandleClient(client));
                }
            });

            // ==========================================================
            // [THÊM MỚI] KÍCH HOẠT NHỊP TIM (HEARTBEAT) THEO DÕI THỜI GIAN
            // ==========================================================
            Task.Run(async () =>
            {
                Console.WriteLine("[SYSTEM] Hệ thống giám sát thời gian chờ món (SLA) đã khởi động.");

                while (_isRunning)
                {
                    // Cứ 1 phút (60000 mili-giây) Server sẽ tự động quét 1 lần.
                    // (Bạn có thể giảm xuống 30000 nếu muốn quét mỗi 30 giây)
                    await Task.Delay(60000);

                    try
                    {
                        // Quét các món đã đợi quá 15 phút (Bạn có thể đổi số 15 thành số phút bạn muốn)
                        bool hasChanges = await ServiceManager.Kitchen.AutoScanPriorityItemsAsync(15);

                        if (hasChanges)
                        {
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] BÁO ĐỘNG: Có món ăn quá giờ, tự động bật Ưu Tiên!");

                            // Phát tín hiệu Realtime dội xuống toàn bộ màn hình Bếp để nhảy UI
                            await Broadcast("RELOAD_KITCHEN_MAP");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Heartbeat Error] {ex.Message}");
                    }
                }
            });
            // ==========================================================
        }

        private async Task<string> HandleSendMessage(string[] parts, int senderId)
        {
            Console.WriteLine("!!!!!!!!!! ENTERED HandleSendMessage - THIS BUILD !!!!!!!!!!");
            if (parts.Length < 3) return "ERROR|Invalid_Format";

            string recipientStr = parts[1];
            string msgJson = parts[2];

            int? toUserId = (recipientStr == "null" || string.IsNullOrEmpty(recipientStr))
                ? null
                : int.Parse(recipientStr);

            var msg = JsonConvert.DeserializeObject<TinNhan>(msgJson);
            if (msg == null) return "ERROR|Invalid_Json";

           

            string normalizedJson = JsonConvert.SerializeObject(msg);
            Console.WriteLine($"[DEBUG] About to save - RecipientId: {(msg.RecipientId.HasValue ? msg.RecipientId.Value.ToString() : "NULL")}");
            await ServiceManager.User.SaveMessageToDatabase(msg);

            if (!toUserId.HasValue) // Broadcast
            {
                foreach (var client in _activeClients)
                {
                    Console.WriteLine("[DEBUG] Đang thực hiện Broadcast cho mọi người...");
                    if (client.Key != senderId)
                    {
                        byte[] data = Encoding.UTF8.GetBytes("NEW_MESSAGE|" + normalizedJson);
                        await client.Value.WriteAsync(data, 0, data.Length);
                    }
                }
                return "SUCCESS|Broadcasted";
            }
            else
            {
                if (_activeClients.TryGetValue(toUserId.Value, out var stream))
                {
                    byte[] data = Encoding.UTF8.GetBytes("NEW_MESSAGE|" + normalizedJson);
                    await stream.WriteAsync(data, 0, data.Length);
                    return "SUCCESS|Sent_Online";
                }
                return "SUCCESS|Sent_Saved_To_DB";
            }
        }


        private async void HandleClient(TcpClient client)
        {
            using NetworkStream stream = client.GetStream();

            //Khi một Client kết nối, cho họ vào danh sách nhận tin
            lock (_activeStreams) { _activeStreams.Add(stream); }

            byte[] buffer = new byte[8192];

            // Biến nhớ ID của người dùng đang kết nối Socket
            int currentUserId = 0;

            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim('\0', ' ', '\r', '\n');
                    
                    Console.WriteLine($"[CLIENT SAYS]: {request}");

                    string response = await ProcessRequest(request, currentUserId);

                    // Nếu lệnh LOGIN thành công --> ghi nhớ ID vào biến currentUserId
                    if (response.StartsWith("LOGIN_SUCCESS"))
                    {
                        string[] resParts = response.Split('|');
                        currentUserId = int.Parse(resParts[1]); // Lưu MaNguoiDung vào đây
                        _activeClients.TryAdd(currentUserId, stream);
                    }
                    // Nếu lệnh LOGOUT thành công --> xóa ID đi
                    else if (response == "LOGOUT_SUCCESS")
                    {
                        currentUserId = 0;
                    }

                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DISCONNECT] Client {client.Client.RemoteEndPoint} đã ngắt kết nối.");
            }
            finally
            {
                //Khi Client thoát, xóa khỏi danh sách
                lock (_activeStreams) { _activeStreams.Remove(stream); }

                // khi kết nối đóng
                if (currentUserId != 0)
                {
                    // cập nhật Offline cho ID đã ghi nhớ
                    _activeClients.TryRemove(currentUserId, out _);
                    await ServiceManager.User.UpdateOnlineStatusAsync(currentUserId, false);
                    Console.WriteLine($"[STATUS] User ID {currentUserId} đã Offline.");
                }
                client.Close();
            }
        }

        private async Task<string> ProcessRequest(string request, int currentUserId)
        {
            // Định dạng gói tin: COMMAND|DATA1|DATA2|...
            if (string.IsNullOrWhiteSpace(request)) return "ERROR|Empty request";
            string[] parts = request.Split('|');
            string command = parts[0];

            switch (command)
            {
                case "LOGIN":
                    var account = await ServiceManager.User.LoginAsync(parts[1], parts[2].Trim());

                    if (account != null)
                    {
                        // Thứ tự dữ liệu: 0:Status | 1:MaND | 2:HoTen | 3:TenDN | 4:Email | 5:VaiTro | 6:SDT
                        return $"LOGIN_SUCCESS|{account.MaNguoiDung}|{account.HoTen}|{account.TenDangNhap}|{account.Email}|{account.VaiTro}|{account.SDT}";
                    }
                    else
                    {
                        return "LOGIN_FAIL|Sai tên đăng nhập hoặc mật khẩu";
                    }

                case "REGISTER":
                    // Gói tin từ Client gửi lên: REGISTER|user|pass|email|phone|fullName|role
                    // parts[0] là "REGISTER"
                    if (parts.Length < 7) return "REGISTER_FAIL|Thiếu thông tin đăng ký!";

                    string regResult = await ServiceManager.User.RegisterAsync(
                        parts[1], // user
                        parts[2], // pass
                        parts[3], // email
                        parts[4], // phone
                        parts[5], // fullName
                        parts[6]  // role
                    );
                    return regResult;

                case "LOGOUT":
                    // Dữ liệu: LOGOUT|manguoidung
                    int logoutId = int.Parse(parts[1]);
                    await ServiceManager.User.UpdateOnlineStatusAsync(logoutId, false);
                    return "LOGOUT_SUCCESS";

                case "CHECK_EMAIL":
                    if (parts.Length < 2) return "ERROR|Thiếu email";
                    string email = parts[1].Trim();

                    if (await ServiceManager.User.IsEmailRegisteredAsync(email))
                    {
                        string otpCode = new Random().Next(100000, 999999).ToString();
                        OtpStorage[email] = otpCode;
                        try
                        {
                            await EmailService.SendOtpAsync(email, otpCode);
                            Console.WriteLine($"[OTP]: Mã của {email} là {otpCode}"); // Log để debug cho dễ
                            return "EMAIL_EXISTS|Mã OTP đã được gửi!";
                        }
                        catch (Exception ex)
                        {
                            return $"ERROR|Lỗi gửi mail: {ex.Message}";
                        }
                    }
                    return "EMAIL_NOT_FOUND|Email không tồn tại!";

                case "VERIFY_OTP":
                    if (parts.Length < 3) return "VERIFY_FAIL";
                    string vEmail = parts[1].Trim();
                    string vOtp = parts[2].Trim();

                    if (OtpStorage.TryGetValue(vEmail, out string actualOtp) && actualOtp == vOtp)
                        return "VERIFY_SUCCESS";
                    return "VERIFY_FAIL";

                case "UPDATE_PASSWORD":
                    if (parts.Length < 3) return "UPDATE_FAIL|Thiếu dữ liệu";

                    string targetEmail = parts[1].Trim();
                    string newPasswordRaw = parts[2].Trim();

                    string hashedNewPassword = CafeCommon.SercurityHelper.HashPassword(newPasswordRaw);

                    bool isUpdated = await ServiceManager.User.UpdateUserPasswordAsync(targetEmail, hashedNewPassword);

                    if (isUpdated)
                    {
                        // 3. Xóa OTP để bảo mật
                        OtpStorage.TryRemove(targetEmail, out _);
                        return "UPDATE_SUCCESS";
                    }
                    return "UPDATE_FAIL|Cập nhật Database không thành công";

                case "UPDATE_PROFILE":
                    // Gói tin: UPDATE_PROFILE|id|fullName|email (không cho chỉnh username và role)
                    if (parts.Length < 4) return "UPDATE_FAIL|Thiếu thông tin cập nhật!";

                    int uid = int.Parse(parts[1]);
                    string newName = parts[2];
                    string newEmail = parts[3];

                    bool isOk = await ServiceManager.User.UpdateProfileAsync(uid, newName, newEmail);
                    return isOk ? "UPDATE_SUCCESS|Cập nhật thành công!" : "UPDATE_FAIL|Lỗi cập nhật Database!";

                case "GET_REVENUE":
                    // Gói tin: GET_REVENUE|2026-04-20|2026-04-21
                    DateTime from = DateTime.Parse(parts[1]).Date;
                    DateTime to = DateTime.Parse(parts[2]).Date.AddDays(1).AddTicks(-1); // Chạy đến cuối ngày

                    var reportData = await ServiceManager.Revenue.GetRevenueByTableAsync(from, to);

                    // Serialize danh sách thành JSON string
                    string jsonResponse = JsonConvert.SerializeObject(reportData);
                    return "REVENUE_SUCCESS|" + jsonResponse;

                case "GET_DISCOUNTS":
                    var list = await ServiceManager.Discount.GetAllAsync();
                    return "SUCCESS|" + JsonConvert.SerializeObject(list);

                case "ADD_DISCOUNT":
                    var newKM = JsonConvert.DeserializeObject<KhuyenMai>(parts[1]);
                    bool isAdded = await ServiceManager.Discount.AddAsync(newKM);
                    return isAdded ? "SUCCESS|Thêm thành công" : "FAIL|Lỗi khi thêm";

                case "DELETE_DISCOUNT":
                    int idDel = int.Parse(parts[1]);
                    bool isDeleted = await ServiceManager.Discount.DeleteAsync(idDel);
                    return isDeleted ? "SUCCESS|Đã xóa" : "FAIL|Không thể xóa";

                case "UPDATE_DISCOUNT":
                    // Dữ liệu: UPDATE_DISCOUNT|{JSON_KHUYEN_MAI}
                    var kmUpdate = JsonConvert.DeserializeObject<KhuyenMai>(parts[1]);
                    bool isUpdated_discount = await ServiceManager.Discount.UpdateAsync(kmUpdate);
                    return isUpdated_discount ? "SUCCESS|Cập nhật thành công!" : "FAIL|Cập nhật thất bại!";

                case "GET_ALL_EMPLOYEES":
                    var requester = await ServiceManager.User.GetUserByIdAsync(currentUserId);
                    if (requester != null && requester.VaiTro == "Admin")
                    {
                        var employees = await ServiceManager.User.GetAllEmployeesAsync();
                        return JsonConvert.SerializeObject(employees);
                    }
                    return "ERROR|Quyền truy cập bị từ chối";

                case "DELETE_EMPLOYEE": // Gói tin: DELETE_EMPLOYEE|id
                    await ServiceManager.User.DeleteEmployeeAsync(int.Parse(parts[1]));
                    return "SUCCESS";

                case "UPDATE_EMPLOYEE": // Gói tin: UPDATE_EMPLOYEE|id|user|name|email|pass|role
                    await ServiceManager.User.UpdateEmployeeBasicAsync(int.Parse(parts[1]), parts[2], parts[3], parts[4], parts[5], parts[6]);
                    return "SUCCESS";

                case "SEARCH_EMPLOYEE":
                    // Gói tin : SEARCH_EMPLOYEE|tên_cần_tìm
                    if (parts.Length < 2) return "[]"; // Trả về mảng rỗng nếu thiếu từ khóa
                    var searchResult = await ServiceManager.User.SearchEmployeesByNameAsync(parts[1]);
                    return JsonConvert.SerializeObject(searchResult);


                case "GET_ALL_MENU":
                    var allMenu = await ServiceManager.Menu.GetAllMenuAsync();
                    return "SUCCESS|" + JsonConvert.SerializeObject(allMenu);

                case "ADD_MENU":
                    // Định dạng: ADD_MENU|MaLoaiMon|TenMon|MoTa|Gia|TrangThai
                    var newItem = new Menu
                    {
                        MaLoaiMon = int.Parse(parts[1]),
                        TenMon = parts[2],
                        MoTa = parts[3],
                        Gia = decimal.Parse(parts[4]),
                        TrangThai = parts[5]
                    };
                    string result = await ServiceManager.Menu.AddMenuAsync(newItem);
                    return result;

                case "UPDATE_MENU":
                    // Định dạng: UPDATE_MENU|MaMon|MaLoaiMon|TenMon|MoTa|Gia|TrangThai
                    var upItem = new Menu
                    {
                        MaMon = int.Parse(parts[1]),
                        MaLoaiMon = int.Parse(parts[2]),
                        TenMon = parts[3],
                        MoTa = parts[4],
                        Gia = decimal.Parse(parts[5]),
                        TrangThai = parts[6]
                    };
                    return await ServiceManager.Menu.UpdateMenuAsync(upItem) ? "SUCCESS" : "FAIL";

                case "DELETE_MENU":
                    return await ServiceManager.Menu.DeleteMenuAsync(int.Parse(parts[1])) ? "SUCCESS" : "FAIL";

                case "SEARCH_MENU":
                    var searchRes = await ServiceManager.Menu.SearchMenuByNameAsync(parts[1]);
                    return JsonConvert.SerializeObject(searchRes);

                case "GET_ALL_CATEGORY":
                    var categories = await ServiceManager.Menu.GetAllCategoriesAsync();
                    return "SUCCESS|" + JsonConvert.SerializeObject(categories);

                case "GET_TABLES":
                    var tables = await ServiceManager.Table.GetAllAsync();

                    // THÊM CẤU HÌNH NÀY: Ép định dạng JSON chuẩn Quốc tế để mọi máy Client đều đọc được
                    var getSettings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss" };

                    return "SUCCESS|" + JsonConvert.SerializeObject(tables, getSettings);

                case "ADD_TABLE":
                    // Cấp Culture Việt Nam để đọc được định dạng dd/MM/yyyy nếu Admin gửi lên
                    var addSettings = new JsonSerializerSettings { Culture = new System.Globalization.CultureInfo("vi-VN") };
                    var newTable = JsonConvert.DeserializeObject<BanAn>(parts[1], addSettings);

                    bool isAdd = await ServiceManager.Table.AddAsync(newTable);
                    if (isAdd)
                    {
                        await Broadcast("RELOAD_TABLE_MAP");
                        return "SUCCESS|Thêm bàn thành công";
                    }
                    return "FAIL|Lỗi khi thêm bàn";

                case "UPDATE_TABLE":
                    var upSettings = new JsonSerializerSettings { Culture = new System.Globalization.CultureInfo("vi-VN") };
                    var tableUp = JsonConvert.DeserializeObject<BanAn>(parts[1], upSettings);

                    bool isUp = await ServiceManager.Table.UpdateAsync(tableUp);
                    if (isUp)
                    {
                        await Broadcast("RELOAD_TABLE_MAP");
                        return "SUCCESS|Cập nhật thành công";
                    }
                    return "FAIL|Lỗi khi cập nhật";

                case "DELETE_TABLE":
                    int idDel_table = int.Parse(parts[1]);
                    string delRes = await ServiceManager.Table.DeleteAsync(idDel_table);
                    if (delRes.StartsWith("SUCCESS"))
                    {
                        await Broadcast("RELOAD_TABLE_MAP");
                    }
                    return delRes;

                case "GET_BILLS":
                    var bills = await ServiceManager.Bill.GetAllAsync();
                    return "SUCCESS|" + JsonConvert.SerializeObject(bills);

                case "UPDATE_TABLE_STATUS":
                    {
                        // Gói tin nhận từ Client: UPDATE_TABLE_STATUS|maBanAn|TrangThaiMoi
                        int tableId = int.Parse(parts[1]);
                        string newStatus = parts[2];

                        try
                        {
                            // =======================================================================
                            // Nếu chuyển từ "Có khách" về "Trống" (Hủy Đơn)
                            // =======================================================================
                            if (newStatus == "Trống")
                            {
                                // 1. Tìm hóa đơn chưa thanh toán (đang treo) của bàn này
                                var billRes = await DatabaseService.Client.From<HoaDon>()
                                    .Where(x => x.MaBanAn == tableId && x.TrangThai == "Chưa thanh toán")
                                    .Get();
                                var activeBill = billRes.Models.FirstOrDefault();

                                // Nếu có hóa đơn đang hoạt động thì thực hiện hủy
                                if (activeBill != null)
                                {
                                    // 2. Cập nhật trạng thái Hóa đơn thành "Đã hủy"
                                    await DatabaseService.Client.From<HoaDon>()
                                        .Where(x => x.MaHD == activeBill.MaHD)
                                        .Set(x => x.TrangThai, "Đã hủy")
                                        .Update();

                                    // 3. Cập nhật trạng thái Đơn hàng thành "Đã hủy" (3)
                                    await DatabaseService.Client.From<DonHang>()
                                        .Where(x => x.MaDonHang == activeBill.MaDonHang)
                                        .Set(x => x.TrangThai, 3)
                                        .Update();

                                    // 4. [VÁ LỖI CỦA BẠN TẠI ĐÂY] Cập nhật TẤT CẢ món ăn trong đơn thành Đã hủy
                                    await DatabaseService.Client.From<CTDonHang>()
                                        .Where(x => x.MaDonHang == activeBill.MaDonHang)
                                        .Set(x => x.TrangThaiItem, 3)
                                        .Set(x => x.GhiChuBep, "Hủy nguyên bàn từ phía phục vụ") // Áp dụng ý tưởng tuyệt vời của bạn!
                                        .Set(x => x.ThoiGianHoanThanh, DateTime.Now) // Chốt mốc thời gian kết thúc
                                        .Update();
                                }

                                // 5. [DỌN DẸP BÀN] Trả lại bàn trống hoàn toàn, xóa tên Nhân viên phục vụ cũ
                                await DatabaseService.Client.From<BanAn>()
                                    .Where(x => x.MaBanAn == tableId)
                                    .Set(x => x.MaNhanVien, null)
                                    .Update();
                            }

                            // =======================================================================
                            // CẬP NHẬT TRẠNG THÁI BÀN ĂN VÀ BÁO CÁO REALTIME
                            // =======================================================================
                            bool isStatusUpdated = await ServiceManager.Table.UpdateStatusAsync(tableId, newStatus);

                            if (isStatusUpdated)
                            {
                                // Phát tín hiệu Realtime cho tất cả các máy
                                await Broadcast("RELOAD_TABLE_MAP");   // Báo Phục vụ load lại màu bàn

                                if (newStatus == "Trống")
                                {
                                    await Broadcast("RELOAD_KITCHEN_MAP"); // Báo Bếp dọn ngay các món vừa bị hủy khỏi màn hình!
                                }

                                return $"SUCCESS|Cập nhật trạng thái bàn sang '{newStatus}' thành công!";
                            }
                            return "FAIL|Lỗi hệ thống, không thể cập nhật trạng thái bàn!";
                        }
                        catch (Exception ex)
                        {
                            return $"FAIL|Lỗi xử lý Server: {ex.Message}";
                        }
                    }

                case "TRANSFER_TABLE":
                    {
                        // Gói tin nhận từ Client: TRANSFER_TABLE|maBanCu|maBanMoi
                        int fromTableId = int.Parse(parts[1]);
                        int toTableId = int.Parse(parts[2]);

                        try
                        {
                            // Gọi hàm TransferTableAsync đã sửa đổi ở lượt trước (Tìm kiếm và xử lý dựa trên bảng HoaDon)
                            bool isTransferOk = await ServiceManager.Table.TransferTableAsync(fromTableId, toTableId);

                            if (isTransferOk)
                            {
                                // Đồng bộ Realtime sơ đồ bàn ăn cho toàn bộ hệ thống nhân viên phục vụ
                                await Broadcast("RELOAD_TABLE_MAP");
                                return "SUCCESS|Chuyển bàn thành công!";
                            }
                            return "FAIL|Chuyển bàn thất bại! (Bàn cũ không có hóa đơn hoạt động hoặc bàn mới không trống)";
                        }
                        catch (Exception ex)
                        {
                            return $"FAIL|Lỗi xử lý hệ thống khi chuyển bàn: {ex.Message}";
                        }
                    }

                case "GET_CATEGORIES":
                    {
                        var categorieslist = await ServiceManager.Menu.GetAllCategoriesAsync();
                        return "SUCCESS|" + JsonConvert.SerializeObject(categorieslist);
                    }

                case "GET_MENU_BY_CATEGORY":
                    {
                        int cateId = int.Parse(parts[1]);
                        List<Menu> menus;

                        if (cateId == 0) // Nếu là "Tất cả"
                        {
                            menus = await ServiceManager.Menu.GetAllMenuAsync(); // Gọi hàm lấy hết
                        }
                        else
                        {
                            menus = await ServiceManager.Menu.GetByCategoryIdAsync(cateId);
                        }
                        return "SUCCESS|" + JsonConvert.SerializeObject(menus);
                    }

                case "SUBMIT_ORDER":
                    {
                        // Gói tin nhận từ Client dạng phẳng: SUBMIT_ORDER|maBanAn|maNguoiDung|JSON_GioHang
                        if (parts.Length < 4) return "FAIL|Thiếu dữ liệu order";
                        if (!int.TryParse(parts[1], out int orderTableId)) return "FAIL|Id bàn không hợp lệ";
                        if (!int.TryParse(parts[2], out int orderStaffId)) return "FAIL|Id nhân viên không hợp lệ";

                        List<CTDonHang> items = null;
                        try
                        {
                            items = JsonConvert.DeserializeObject<List<CTDonHang>>(parts[3]);
                        }
                        catch (Exception jsEx)
                        {
                            return "FAIL|Dữ liệu giỏ hàng không hợp lệ: " + jsEx.Message;
                        }

                        if (items == null || items.Count == 0) return "FAIL|Giỏ hàng rỗng";

                        // Khởi tạo đối tượng đầu đơn hàng từ dữ liệu Socket để truyền vào hàm tổng hợp
                        var orderHeader = new DonHang
                        {
                            MaBanAn = orderTableId,
                            MaNVOrder = orderStaffId,
                            NgayOrder = DateTime.Now,
                            TrangThai = 0, // 0: Đơn hàng mới tinh
                            LoaiDonHang = "Tại chỗ"
                        };

                        // GỌI DUY NHẤT HÀM SỬ LÝ THÔNG MINH ĐÃ VIẾT TRONG ORDER_SERVICE
                        bool isSuccess = await ServiceManager.Order.SubmitOrderAsync(orderHeader, items);

                        if (isSuccess)
                        {
                            // Trạng thái bàn sẽ được cập nhật tự động trực tiếp bên trong hàm SubmitOrderAsync
                            return "SUCCESS|Đã gửi order xuống bếp thành công!";
                        }
                        return "FAIL|Lưu đơn hàng hoặc hóa đơn thất bại trên hệ thống Server!";
                    }

                case "GET_CUSTOMERS":
                    var customers = await ServiceManager.Customer.GetAllAsync();
                    return "SUCCESS|" + JsonConvert.SerializeObject(customers);

                case "ADD_CUSTOMERS":
                    try
                    {
                        var newCustomer = JsonConvert.DeserializeObject<KhachHang>(parts[1]);

                        // It's a good idea to check if the ID is empty before proceeding
                        if (newCustomer.MaKH <= 0)
                            return "FAIL|Mã Khách Hàng không để trống";

                        bool isAdded2 = await ServiceManager.Customer.AddAsync(newCustomer);

                        return isAdded2 ? "SUCCESS|Thêm thành công" : "FAIL|Duplicate ID or Database Error";
                    }
                    catch (Exception ex)
                    {
                        return $"FAIL|Server Error: {ex.Message}";
                    }


                case "DELETE_CUSTOMERS":
                    try
                    {
                        // parts[1] contains the ID sent from the WinForm
                        int idDel2 = int.Parse(parts[1]);

                        bool isDeleted2 = await ServiceManager.Customer.DeleteAsync(idDel2);

                        if (isDeleted2)
                        {

                            return "SUCCESS|Xóa Khách Hàng Thành Công";
                        }
                        return "FAIL|Không thấy khách hàng";
                    }
                    catch (Exception ex)
                    {
                        return $"FAIL|Server Error: {ex.Message}";
                    }

                case "UPDATE_CUSTOMERS":
                    try
                    {
                        // Deserialize the JSON string back into a KhachHang object
                        var customerUpdate = JsonConvert.DeserializeObject<KhachHang>(parts[1]);

                        // Call the service to perform the update in Supabase
                        bool isUpdated2 = await ServiceManager.Customer.UpdateAsync(customerUpdate);

                        if (isUpdated2)
                        {
                            // Optional: Notify other clients to refresh their data
                            // await Broadcast("RELOAD_CUSTOMER_LIST");
                            return "SUCCESS|Cập nhật thông tin khách hàng thành công";
                        }
                        return "FAIL|Lỗi khi cập nhật thông tin khách hàng";
                    }
                    catch (Exception ex)
                    {
                        return $"FAIL|Server Error: {ex.Message}";
                    }

                case "GET_ORDERS_EXTENDED":
                    var orders = await ServiceManager.Order.GetAllOrdersExtendedAsync();
                    string jsonResponse2 = JsonConvert.SerializeObject(orders);

                    // ADD THIS LINE TEMPORARILY:
                    Console.WriteLine($"[DEBUG JSON]: {jsonResponse2}");

                    return "SUCCESS|" + jsonResponse2;

                case "GET_ORDER_DETAILS_EXTENDED":
                    int orderId = int.Parse(parts[1]);
                    var details = await ServiceManager.Order.GetOrderDetailsExtendedAsync(orderId);
                    return "SUCCESS|" + JsonConvert.SerializeObject(details);

                case "DELETE_ORDER":
                    int delId = int.Parse(parts[1]);
                    bool ok = await ServiceManager.Order.DeleteOrderAsync(delId);
                    return ok ? "SUCCESS|Deleted" : "FAIL|Could not delete order";


                case "GET_UNIQUE_TABLES":
                    // FIX: Change the type to List<string> (or use 'var' to let C# infer it automatically)
                    var tableNames = await ServiceManager.Order.GetUniqueTableNamesAsync();

                    return "SUCCESS|" + JsonConvert.SerializeObject(tableNames);

                case "GET_ALL_BILLS":
                    {
                        try
                        {
                            // Fetch bills (no join) then resolve TenBan per bill to avoid PostgREST join alias issues
                            var billRes = await DatabaseService.Client.From<HoaDon>().Order(x => x.NgayTao, Supabase.Postgrest.Constants.Ordering.Descending).Get();
                            var billModels = billRes.Models;

                            var flatBills = new List<object>();
                            foreach (var bill in billModels)
                            {
                                string tenBanHienThi = "Mang về";
                                if (bill.MaBanAn.HasValue && bill.MaBanAn > 0)
                                {
                                    try
                                    {
                                        var banRes = await DatabaseService.Client.From<BanAn>().Where(x => x.MaBanAn == bill.MaBanAn.Value).Get();
                                        var ban = banRes.Models.FirstOrDefault();
                                        if (ban != null && !string.IsNullOrEmpty(ban.TenBan)) tenBanHienThi = ban.TenBan;
                                        else tenBanHienThi = $"Bàn {bill.MaBanAn}";
                                    }
                                    catch { tenBanHienThi = $"Bàn {bill.MaBanAn}"; }
                                }

                                flatBills.Add(new
                                {
                                    MaHD = bill.MaHD,
                                    MaBan = bill.MaBanAn,
                                    TenBan = tenBanHienThi,
                                    TongTien = bill.TongTien,
                                    NgayTao = bill.NgayTao.ToString("dd/MM/yyyy"),
                                    TrangThai = bill.TrangThai ?? "Chưa thanh toán",
                                    MaKH = bill.MaKH
                                });
                            }

                            return "SUCCESS|" + JsonConvert.SerializeObject(flatBills);
                        }
                        catch (Exception ex)
                        {
                            return $"ERROR|{ex.Message}";
                        }
                    }

                case "SEARCH_BILL_BY_ID":
                    {
                        try
                        {
                            string searchId = parts[1];
                            var billresult = await DatabaseService.Client.From<HoaDon>()
                                .Filter("mahd", Supabase.Postgrest.Constants.Operator.Equals, searchId)
                                .Get();

                            // Return SUCCESS prefix for consistency, or just the JSON if your client expects it
                            return JsonConvert.SerializeObject(billresult.Models);
                        }
                        catch (Exception ex)
                        {
                            return $"ERROR|{ex.Message}";
                        }
                    }

                case "GET_CUSTOMER_BY_PHONE":
                    {
                        // 1. Kiểm tra dữ liệu đầu vào (parts[1] tương ứng với SDT gửi từ Client)
                        if (parts.Length < 2) return "FAIL|Thiếu số điện thoại";

                        string phone = parts[1];

                        // 2. Gọi hàm async từ ServiceManager (sử dụng await thay vì .Wait())
                        var customerInfo = await ServiceManager.Customer.GetCustomerByPhoneAsync(phone);

                        // 3. Trả về kết quả dưới dạng string để hàm HandleClient gửi đi
                        if (customerInfo != null)
                        {
                            return "SUCCESS|" + JsonConvert.SerializeObject(customerInfo);
                        }
                        return "NOT_FOUND";
                    }

                case "GET_CUSTOMER_BY_ID":
                    if (parts.Length < 2) return "ERROR|Missing ID";
                    // Gọi Service tìm khách hàng theo MaKH
                    var customerById = await ServiceManager.Customer.GetCustomerByIdAsync(int.Parse(parts[1]));
                    return customerById != null ? "SUCCESS|" + JsonConvert.SerializeObject(customerById) : "NOT_FOUND";
                case "GET_DISCOUNT_BY_CODE":
                    {
                        try
                        {
                            if (parts.Length < 2) return "ERROR|Missing Code";
                            string voucherCode = parts[1].Trim();

                            var promoResult = await DatabaseService.Client.From<KhuyenMai>()
                                .Filter("codekm", Supabase.Postgrest.Constants.Operator.Equals, voucherCode)
                                .Get();

                            var km = promoResult.Models.FirstOrDefault();

                            if (km != null && km.TrangThai && km.NgayBatDau <= DateTime.Now && km.NgayHetHan >= DateTime.Now)
                            {
                                return "SUCCESS|" + JsonConvert.SerializeObject(km);
                            }
                            return "NOT_FOUND";
                        }
                        catch (Exception ex) { return $"ERROR|{ex.Message}"; }
                    }

                case "CONFIRM_PAYMENT":
                    {
                        try
                        {
                            int maHD = int.Parse(parts[1]);
                            int? maBan = string.IsNullOrEmpty(parts[2]) ? (int?)null : int.Parse(parts[2]);
                            int? maKH = string.IsNullOrEmpty(parts[3]) ? (int?)null : int.Parse(parts[3]);

                            // Đọc số theo chuẩn InvariantCulture để tránh lỗi hệ thống phân tách thập phân
                            decimal soTien = decimal.Parse(parts[4], System.Globalization.CultureInfo.InvariantCulture);
                            string phuongThuc = parts[5];
                            float diemDaDung = parts.Length > 6 ? float.Parse(parts[6], System.Globalization.CultureInfo.InvariantCulture) : 0f;

                            // Đọc thông tin khách hàng thành viên bổ sung từ Client gửi lên
                            string tenKH = parts.Length > 7 ? parts[7] : "";
                            string sdtKH = parts.Length > 8 ? parts[8] : "";

                            // Lấy thông tin hóa đơn hiện tại để biết mã đơn hàng (MaDonHang) liên quan
                            var resBillCur = await DatabaseService.Client.From<HoaDon>().Where(x => x.MaHD == maHD).Get();
                            var currentBillObj = resBillCur.Models.FirstOrDefault();

                            int maDonHangLienQuan = currentBillObj != null ? currentBillObj.MaDonHang : 0;

                            // 1. Khởi tạo truy vấn cập nhật Hóa đơn
                            var updateBillQuery = DatabaseService.Client.From<HoaDon>()
                                .Where(x => x.MaHD == maHD)
                                .Set(x => x.TrangThai, "Đã thanh toán")
                                .Set(x => x.ThanhTien, soTien)
                                .Set(x => x.PhuongThucThanhToan, phuongThuc);

                            if (maKH.HasValue && maKH.Value > 0)
                            {
                                updateBillQuery = updateBillQuery.Set(x => x.MaKH, maKH.Value);
                            }

                            await updateBillQuery.Update();

                            // 1b. Cập nhật Đơn hàng (DonHang) liên quan
                            // Nếu có thông tin khách hàng thành viên, cập nhật vào bảng Đơn hàng thông qua mã đơn hàng liên quan
                            if (maDonHangLienQuan > 0)
                            {
                                // Cập nhật thông tin khách hàng nếu có
                                if (!string.IsNullOrEmpty(tenKH) || !string.IsNullOrEmpty(sdtKH))
                                {
                                    await DatabaseService.Client.From<DonHang>()
                                        .Where(x => x.MaDonHang == maDonHangLienQuan)
                                        .Set(x => x.TenKH, tenKH)   // Sử dụng đúng thuộc tính TenKH trong DonHang.cs
                                        .Set(x => x.SDTKH, sdtKH)   // Sử dụng đúng thuộc tính SDTKH trong DonHang.cs
                                        .Update();
                                }

                                // Cập nhật trạng thái đơn hàng sang 2: Hoàn thành
                                await DatabaseService.Client.From<DonHang>()
                                    .Where(x => x.MaDonHang == maDonHangLienQuan)
                                    .Set(x => x.TrangThai, 2)
                                    .Update();

                                // Cập nhật tất cả item của đơn hàng (ctdonhang) sang trạng thái 2: Xong và set thời gian hoàn thành
                                await DatabaseService.Client.From<CTDonHang>()
                                    .Where(x => x.MaDonHang == maDonHangLienQuan)
                                    .Set(x => x.TrangThaiItem, 2)
                                    .Set(x => x.ThoiGianHoanThanh, DateTime.Now)
                                    .Update();
                            }

                            // 2. Cập nhật Bàn ăn
                            if (maBan.HasValue && maBan > 0)
                            {
                                await DatabaseService.Client.From<BanAn>()
                                    .Where(x => x.MaBanAn == maBan.Value)
                                    .Set(x => x.TrangThai, "Trống")
                                    .Set(x => x.MaNhanVien, null)
                                    .Update();
                            }


                            // 3. Tích điểm thành viên (Cứ 100k cộng 1 điểm)
                            if (maKH.HasValue && maKH > 0)
                            {
                                var resKH = await DatabaseService.Client.From<KhachHang>().Where(x => x.MaKH == maKH.Value).Get();
                                var kh = resKH.Models.FirstOrDefault();

                                if (kh != null)
                                {
                                    // Lấy tổng tiền chia cho 100,000 và làm tròn xuống để lấy số điểm chẵn được cộng thêm
                                    float diemTichLuyMoi = (float)Math.Floor((double)soTien / 100000);

                                    // Điểm cuối cùng = Điểm hiện tại - Điểm đã tiêu ở HD này + Điểm vừa được thưởng
                                    float diemCapNhat = kh.DiemTichLuy - diemDaDung + diemTichLuyMoi;
                                    if (diemCapNhat < 0) diemCapNhat = 0f;

                                    await DatabaseService.Client.From<KhachHang>()
                                        .Where(x => x.MaKH == maKH.Value)
                                        .Set(x => x.DiemTichLuy, diemCapNhat)
                                        .Update();
                                }
                            }

                            await Broadcast("RELOAD_TABLE_MAP");
                            return "PAYMENT_SUCCESS";
                        }
                        catch (Exception ex) { return $"ERROR|{ex.Message}"; }
                    }

                case "GET_KITCHEN_ITEMS":
                    {
                        // 1. Kéo danh sách món ăn đang chờ/đang làm
                        var items = await ServiceManager.Kitchen.GetPendingKitchenItemsAsync();

                        // 2. Ép chuẩn thời gian ISO để không bị crash khi truyền qua mạng
                        var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss" };

                        // 3. Trả về Client kèm tiền tố SUCCESS|
                        return "SUCCESS|" + JsonConvert.SerializeObject(items, settings);
                    }

                case "GET_KITCHEN_STAFF":
                    {
                        try
                        {
                            var kitchenStaff = await ServiceManager.Kitchen.GetKitchenStaffAsync();
                            return "SUCCESS|" + JsonConvert.SerializeObject(kitchenStaff);
                        }
                        catch (Exception ex)
                        {
                            return "ERROR|" + ex.Message;
                        }
                    }

                case "UPDATE_KITCHEN_ITEM":
                    {
                        // Cú pháp kỳ vọng: UPDATE_KITCHEN_ITEM | MaCT | TrangThai | MaNhanVienCheBien | ThoiGianDuKien | GhiChuBep
                        if (parts.Length < 6) return "FAIL|Thiếu tham số cập nhật món ăn bếp!";

                        // 1. Bóc tách dữ liệu bắt buộc
                        if (!int.TryParse(parts[1], out int maCT)) return "FAIL|Mã chi tiết món không hợp lệ!";
                        if (!int.TryParse(parts[2], out int trangThaiMoi)) return "FAIL|Trạng thái không hợp lệ!";

                        // 2. Bóc tách dữ liệu có thể Null (Đầu bếp, Thời gian dự kiến, Ghi chú)
                        int? maDauBep = int.TryParse(parts[3], out int parsedDauBep) ? parsedDauBep : (int?)null;
                        int? thoiGianDuKien = int.TryParse(parts[4], out int parsedThoiGian) ? parsedThoiGian : (int?)null;
                        string ghiChu = parts[5].Trim(); // Có thể rỗng, sẽ được chặn validation ở Client

                        // 3. Gọi "Bộ não" xử lý thời gian ở KitchenService
                        string res = await ServiceManager.Kitchen.UpdateKitchenItemAsync(maCT, trangThaiMoi, maDauBep, thoiGianDuKien, ghiChu);

                        if (res.Contains("SUCCESS"))
                        {
                            // Bắn tín hiệu Realtime cho toàn bộ các máy tính Bếp khác tải lại lưới (Làm mất món hoặc cập nhật trạng thái mới)
                            await Broadcast("RELOAD_KITCHEN_MAP");
                        }

                        return res;
                    }

                case "GET_KITCHEN_REPORT_DATA":
                    try
                    {
                        // Phân tách dữ liệu nhận được từ Client: "GET_KITCHEN_REPORT_DATA|tuNgay;denNgay;maDauBep"
                        var dataParts = request.Split('|')[1].Split(';');
                        DateTime tuNgay = DateTime.Parse(dataParts[0]);
                        DateTime denNgay = DateTime.Parse(dataParts[1]);
                        int maDauBep = int.Parse(dataParts[2]);

                        var reportData2 = await ServiceManager.Kitchen.GetKitchenReportDataAsync(tuNgay, denNgay, maDauBep);
                        return "SUCCESS|" + JsonConvert.SerializeObject(reportData2);
                    }
                    catch (Exception ex)
                    {
                        return "ERROR|" + ex.Message;
                    }

                case "GET_MENU":
                    var menuItems = await ServiceManager.Menu.GetAllMenuAsync(); // Giả định hàm lấy hết Menu trong MenuService
                    return "SUCCESS|" + JsonConvert.SerializeObject(menuItems);

                case "GET_LOAI_MON":
                    // Nếu bạn chưa tạo LoaiMonService, có thể gọi trực tiếp DatabaseService.Client hoặc qua Service tương ứng
                    var resLoaiMon = await DatabaseService.Client.From<LoaiMon>().Get();
                    return "SUCCESS|" + JsonConvert.SerializeObject(resLoaiMon.Models);

                case "GET_ALL_TABLE_NAMES":
                    {
                        var allTableNames = await ServiceManager.Order.GetUniqueTableNamesAsync();
                        return "ALL_TABLE_NAMES_DATA|" + JsonConvert.SerializeObject(allTableNames);
                    }

                case "GET_BEP_ORDERS":
                    {
                        var bepOrders = await ServiceManager.Kitchen.GetKitchenOrdersAsync();
                        return "BEP_ORDERS_DATA|" + JsonConvert.SerializeObject(bepOrders);
                    }

                case "GET_CHAT_USERS":
                    try
                    {
                        // Gọi service để lấy danh sách từ Supabase
                        var users = await ServiceManager.User.GetAllEmployeesAsync();

                        // Trả về kết quả đã được Serialize sang JSON
                        return "SUCCESS|" + JsonConvert.SerializeObject(users);
                    }
                    catch (Exception ex)
                    {
                        return "ERROR|" + ex.Message;
                    }

                case "SEND_MESSAGE":
                    return await HandleSendMessage(parts, currentUserId);


                case "SEARCH_USER":
                    if (parts.Length < 2) return "ERROR|Missing parameter";

                    var searchResult3 = await ServiceManager.User.SearchUsersByUsernameAsync(parts[1]);
                    return "SUCCESS|" + JsonConvert.SerializeObject(searchResult3);

                case "GET_BANK_INFO":
                    try
                    {
                        // Khởi tạo bộ đọc file JSON
                        var config = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .Build();

                        string bankBin = config["BankSettings:BankBin"] ?? "970422";
                        string bankAcc = config["BankSettings:BankAccount"] ?? "0909701503";
                        string accName = config["BankSettings:AccountName"] ?? "HUYNH DANG KHOA";

                        // Gửi trả lại cho Client theo cú pháp: SUCCESS|BankBin|BankAcc|AccountName
                        return $"SUCCESS|{bankBin}|{bankAcc}|{accName}";
                    }
                    catch
                    {
                        return "ERROR|Lỗi đọc cấu hình ngân hàng trên Server";
                    }
                default:
                    return "UNKNOWN_COMMAND";
            }
        }

        public static async Task Broadcast(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            List<NetworkStream> targets;
            lock (_activeStreams) { targets = _activeStreams.ToList(); }

            foreach (var s in targets)
            {
                try { await s.WriteAsync(data, 0, data.Length); }
                catch { /* Bỏ qua nếu stream lỗi */ }
            }
        }
    }
}
