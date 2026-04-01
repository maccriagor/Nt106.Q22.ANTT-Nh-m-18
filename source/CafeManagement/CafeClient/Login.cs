using CafeCommon;
using System.Net.Sockets;
using System.Text.Json;

namespace CafeClient
{
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if the user actually typed something (Basic validation)
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                // 1. Establish the connection (Task 2)
                using (TcpClient client = new TcpClient("127.0.0.1", 8080))
                using (NetworkStream stream = client.GetStream())
                {
                    // 2. Hash the password (Task 3)
                    // We extract the text directly using .Text
                    string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text);

                    var acc = new Account
                    {
                        Username = txtUsername.Text,
                        Password = hashedPassword,
                        Role = "Waiter" // You can later change this to a ComboBox selection
                    };

                    // 3. Wrap and Send
                    var packet = NetworkPacket<Account>.Create(PacketType.Login, acc);
                    string json = JsonSerializer.Serialize(packet);
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(json);

                    await stream.WriteAsync(data, 0, data.Length);

                    MessageBox.Show($"Login sent for {acc.Username}!\nHash: {hashedPassword.Substring(0, 10)}...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
