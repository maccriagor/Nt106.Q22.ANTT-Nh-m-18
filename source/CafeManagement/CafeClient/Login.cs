namespace CafeClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Register registerform = new Register();
            registerform.Show();
            this.Hide();
        }
    }
}
