using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace wpfZarzadzanieKomputer
{
    public partial class StartSessionWindow : Window
    {
        public User SelectedUser { get; private set; }
        public string SelectedComputer { get; private set; }

        public StartSessionWindow(ObservableCollection<User> users)
        {
            InitializeComponent();
            UserComboBox.ItemsSource = users;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser = UserComboBox.SelectedItem as User;
            SelectedComputer = (ComputerComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (SelectedUser == null || string.IsNullOrEmpty(SelectedComputer))
            {
                MessageBox.Show("Wybierz użytkownika i komputer!");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}