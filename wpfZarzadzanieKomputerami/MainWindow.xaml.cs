using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace wpfZarzadzanieKomputer
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> Users;

        public MainWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>();
            UsersGrid.ItemsSource = Users;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            string accountType =
                (AccountTypeBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            decimal balance = 0;
            decimal.TryParse(BalanceBox.Text, out balance);

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Podaj login!");
                return;
            }

            Users.Add(new User
            {
                Login = login,
                Password = password,
                AccountType = accountType,
                Balance = balance
            });

            ClearForm();
        }

        private void ClearForm()
        {
            LoginBox.Text = "";
            PasswordBox.Password = "";
            AccountTypeBox.SelectedIndex = -1;
            BalanceBox.Text = "";
        }
    }

    // MODEL
    public class User
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string AccountType { get; set; } = "";
        public decimal Balance { get; set; }
    }
}