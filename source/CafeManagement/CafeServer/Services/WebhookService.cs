using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CafeCommon; // Để truy cập model HoaDon

namespace CafeServer.Services
{
    public class WebhookService
    {
        public void StartListener()
        {
            Task.Run(async () =>
            {
                try
                {
                    HttpListener listener = new HttpListener();
                    // Lắng nghe ở port 8080
                    // SỬA Ở ĐÂY: Dùng dấu + để cho phép cả localhost lẫn link Ngrok đi vào
                    // Đồng thời thêm "/webhook/" để khớp với đường dẫn bạn đã thiết lập trên SePay
                    listener.Prefixes.Add("http://+:8080/");
                    listener.Prefixes.Add("http://+:8080/webhook/");
                    listener.Start();
                    Console.WriteLine("[Webhook] Đang lắng nghe giao dịch ngân hàng tại port 8080...");

                    while (true)
                    {
                        var context = await listener.GetContextAsync();
                        var request = context.Request;

                        using (var reader = new StreamReader(request.InputStream))
                        {
                            string json = await reader.ReadToEndAsync();
                            _ = ProcessTransaction(json);
                        }

                        context.Response.StatusCode = 200;
                        context.Response.Close();
                    }
                }
                catch (Exception ex)
                {
                    // NẾU THẤY DÒNG NÀY IN RA, 100% LÀ DO CHƯA RUN AS ADMINISTRATOR
                    Console.WriteLine($"\n[CẢNH BÁO WEBHOOK] Lỗi không thể mở cổng: {ex.Message}");
                }
            });
        }

        private async Task ProcessTransaction(string jsonPayload)
        {
            try
            {
                Console.WriteLine($"\n=== CÓ BIẾN ĐỘNG SỐ DƯ TỪ SEPAY ===");
                Console.WriteLine(jsonPayload);

                Match match = Regex.Match(jsonPayload.ToUpper(), @"HD\s*(\d+)");

                if (match.Success)
                {
                    int maHD = int.Parse(match.Groups[1].Value);

                    // Đã đổi tên biến thành jsonParsed để không bị lỗi gạch đỏ trùng tên
                    Newtonsoft.Json.Linq.JObject jsonParsed = Newtonsoft.Json.Linq.JObject.Parse(jsonPayload);
                    string maGiaoDich = jsonParsed["referenceCode"]?.ToString() ?? jsonParsed["id"]?.ToString() ?? "N/A";

                    // Phát lệnh có kèm Mã Giao Dịch
                    SocketServer.Broadcast($"AUTO_PAID|{maHD}|{maGiaoDich}");
                    Console.WriteLine($"[Thành công] Đã phát lệnh chốt HD: {maHD} - Mã GD: {maGiaoDich}");
                }
                else
                {
                    Console.WriteLine("[Thất bại] Giao dịch không chứa mã hóa đơn (VD: HD123) hợp lệ!");
                }
                Console.WriteLine($"===================================\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Lỗi xử lý Webhook] {ex.Message}");
            }
        }
    }
}