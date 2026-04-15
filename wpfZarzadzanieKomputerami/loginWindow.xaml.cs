using System.Windows;
using System.Windows.Controls;

namespace wpfZarzadzanieKomputer
{
    public partial class LoginWindow : Window
    {
        public bool IsAuthenticated { get; private set; } = false;

        private const string AdminLogin = "admin";
        private const string AdminPassword = "1234";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == AdminLogin &&
                PasswordBox.Password == AdminPassword)
            {
                IsAuthenticated = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło");
            }
        }
    }
}