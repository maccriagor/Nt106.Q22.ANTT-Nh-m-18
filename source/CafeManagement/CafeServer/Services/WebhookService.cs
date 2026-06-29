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
                    listener.Prefixes.Add("http://127.0.0.1:8080/");
                    listener.Prefixes.Add("http://localhost:8080/");
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
                JObject data = JObject.Parse(jsonPayload);
                string content = data["content"]?.ToString().ToUpper() ?? "";

                // Tìm nội dung chuyển khoản có chữ HD...
                Match match = Regex.Match(content, @"HD\s*(\d+)");
                if (match.Success)
                {
                    int maHD = int.Parse(match.Groups[1].Value);

                    // BỎ PHẦN UPDATE DATABASE Ở ĐÂY.
                    // Chỉ phát tín hiệu về cho màn hình Thu Ngân để Thu Ngân tự chốt đơn
                    SocketServer.Broadcast($"AUTO_PAID|{maHD}");
                    Console.WriteLine($"[Webhook] Nhận được tiền cho HD {maHD}, đã báo về Client để chốt đơn...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Webhook Parser Error] {ex.Message}");
            }
        }
    }
}