using CafeCommon;
using System;
using System.Collections.Concurrent; // Required for ConcurrentDictionary
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Supabase.Postgrest;

namespace CafeServer
{
    internal class Program
    {
        // FIX: You must define the dictionary here to manage the list
        private static ConcurrentDictionary<string, TcpClient> onlineClients = new ConcurrentDictionary<string, TcpClient>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Connecting to Supabase...");
            await DatabaseService.InitializeAsync();
            Console.WriteLine("Database connected!");

            // Using 8080 as your port
            TcpListener server = new TcpListener(IPAddress.Any, 8080);
            server.Start();
            Console.WriteLine("Server started on port 8080...");

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = HandleClient(client);
            }
        }

        static async Task HandleClient(TcpClient client)
        {
            string clientInfo = client.Client.RemoteEndPoint.ToString();
            string userDisplayName = "Unknown";

            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0) return;

                    string json = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Deserialization connects this to NetworkPacket.cs
                    var packet = JsonSerializer.Deserialize<NetworkPacket<LoginRequest>>(json);

                    if (packet != null && packet.Command == PacketType.Login)
                    {
                        var loginData = packet.Payload;

                        // 2. TRUY VẤN SUPABASE: Tìm người dùng theo TenDangNhap
                        var result = await DatabaseService.Client
                            .From<UserAccount>()
                            .Where(x => x.TenDangNhap == loginData.TenDangNhap)
                            .Get();

                        var user = result.Models.FirstOrDefault();

                        // 3. KIỂM TRA MẬT KHẨU (So sánh chuỗi Hash đã băm từ Client)
                        if (user != null && user.MatKhau == loginData.MatKhau)
                        {
                            // ĐĂNG NHẬP THÀNH CÔNG
                            userDisplayName = user.HoTen;
                            string sessionToken = Guid.NewGuid().ToString();

                            // Cập nhật trạng thái vào DB
                            user.TrangThaiOnline = true;
                            user.Token = sessionToken;
                            await user.Update<UserAccount>();

                            // Ghi log ra màn hình Server
                            Console.WriteLine($"[SUCCESS] {user.HoTen} ({user.VaiTro}) đã đăng nhập từ {clientInfo}");

                            // 4. GỬI PHẢN HỒI VỀ CLIENT (Success = true)
                            var response = new LoginResponse
                            {
                                IsSuccess = true,
                                Token = sessionToken,
                                Role = user.VaiTro,
                                FullName = user.HoTen,
                                Message = "Đăng nhập thành công!"
                            };
                            await SendResponse(stream, PacketType.LoginResponse, response);
                        }
                        else
                        {
                            // THẤT BẠI
                            Console.WriteLine($"[FAILED] Đăng nhập sai cho tài khoản: {loginData.TenDangNhap}");
                            var errorResponse = new LoginResponse { IsSuccess = false, Message = "Sai tài khoản hoặc mật khẩu!" };
                            await SendResponse(stream, PacketType.LoginResponse, errorResponse);
                            return; // Ngắt kết nối nếu sai
                        }
                    }

                    // Keep the connection alive
                    while (client.Connected)
                    {
                        byte[] keepAliveBuffer = new byte[1024];
                        if (await stream.ReadAsync(keepAliveBuffer, 0, keepAliveBuffer.Length) == 0) break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with {clientInfo}: {ex.Message}");
            }
            finally
            {
                // Task 1: Remove from the online list
                onlineClients.TryRemove(userDisplayName + "_" + clientInfo, out _);
                Console.WriteLine($"[DISCONNECTED] {userDisplayName} left.");
                client.Close();
            }
        }

        // Hàm hỗ trợ gửi dữ liệu ngược lại cho Client
        static async Task SendResponse<T>(NetworkStream stream, PacketType type, T payload)
        {
            var responsePacket = NetworkPacket<T>.Create(type, payload);
            string json = JsonSerializer.Serialize(responsePacket);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
            await stream.WriteAsync(data, 0, data.Length);
        }
    }
}