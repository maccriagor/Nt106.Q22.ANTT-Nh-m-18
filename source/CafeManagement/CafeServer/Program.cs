using CafeCommon;
using System;
using System.Collections.Concurrent; // Required for ConcurrentDictionary
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeServer
{
    internal class Program
    {
        // FIX: You must define the dictionary here to manage the list
        private static ConcurrentDictionary<string, TcpClient> onlineClients = new ConcurrentDictionary<string, TcpClient>();

        static async Task Main(string[] args)
        {
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
            string role = "Unknown";

            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0) return;

                    string json = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Deserialization connects this to NetworkPacket.cs
                    var packet = JsonSerializer.Deserialize<NetworkPacket<Account>>(json);

                    if (packet != null && packet.Command == PacketType.Login)
                    {
                        // Access the data through the 'Payload' property now
                        role = packet.Payload.Role;

                        onlineClients.TryAdd(role + "_" + clientInfo, client);
                        Console.WriteLine($"[CONNECTED] {role} joined from {clientInfo}");
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
                onlineClients.TryRemove(role + "_" + clientInfo, out _);
                Console.WriteLine($"[DISCONNECTED] {role} left.");
                client.Close();
            }
        }
    }
}