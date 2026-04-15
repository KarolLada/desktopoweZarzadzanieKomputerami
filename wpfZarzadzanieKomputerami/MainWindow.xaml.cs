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

        // 🆕 USUWANIE UŻYTKOWNIKA
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show(
                    $"Czy na pewno chcesz usunąć użytkownika: {selectedUser.Login}?",
                    "Potwierdzenie",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Users.Remove(selectedUser);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz użytkownika do usunięcia!");
            }
        }

        private void ClearForm()
        {
            LoginBox.Text = "";
            PasswordBox.Password = "";
            AccountTypeBox.SelectedIndex = -1;
            BalanceBox.Text = "";
        }

        private void StartSession_Click(object sender, RoutedEventArgs e)
        {
            var window = new StartSessionWindow(Users);
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                var user = window.SelectedUser;
                var computer = window.SelectedComputer;

                MessageBox.Show($"Uruchomiono sesję:\nUżytkownik: {user.Login}\nKomputer: {computer}");
            }
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