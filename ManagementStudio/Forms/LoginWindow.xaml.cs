using ManagementStudio.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementStudio
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, INotifyPropertyChanged
    {
        public LoginWindow()
        {
           
            DataContext = this;
            InitializeComponent();
        }
        private string boundText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set { 
                boundText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BoundText)));
            }
        }

        private void TextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }
        private void Login()
        {
            if (ctbUsername.Text == "Admin" && ctbPassword.Password == "12345")
            {
                MainWindow main = new MainWindow();
                this.Hide();
                main.Show();
            }
        }
    }
}
