using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace wpfZarzadzanieKomputer
{
    public partial class LoginWindow : Window
    {
        public bool IsAuthenticated { get; private set; } = false;
        public User? LoggedUser { get; private set; }

        private readonly ObservableCollection<User> _users;

        private const string AdminLogin = "admin";
        private const string AdminPassword = "1234";

        public LoginWindow(ObservableCollection<User> users)
        {
            InitializeComponent();
            _users = users;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            if (login == AdminLogin && password == AdminPassword)
            {
                LoggedUser = new User
                {
                    Login = "admin",
                    AccountType = "Administracyjne"
                };

                IsAuthenticated = true;
                Close();
                return;
            }

            var user = _users.FirstOrDefault(u =>
                u.Login == login &&
                u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Błędny login lub hasło");
                return;
            }

            LoggedUser = user;
            IsAuthenticated = true;
            Close();
        }
    }
}