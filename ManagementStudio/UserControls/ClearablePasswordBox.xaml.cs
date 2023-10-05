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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementStudio.UserControls
{
    /// <summary>
    /// Interaction logic for ClearablePasswordBox.xaml
    /// </summary>
    public partial class ClearablePasswordBox : UserControl, INotifyPropertyChanged
    {
        private string _hint;
        public string Hint
        {
            get
            {
                return _hint;
            }
            set
            {
                _hint = value;
                OnPropertyChanged(nameof(Hint));
            }
        }
        public string Password { 
            get
            {
                return tbInput.Password;
            }
        }
        public ClearablePasswordBox()
        {
            InitializeComponent();
            this.PropertyChanged += ClearablePasswordBox_PropertyChanged;
        }

        private void ClearablePasswordBox_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Hint)) 
                tbHint.Text = Hint;  
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Clear();
        }



        private void tbInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbInput.Password))
            {
                tbHint.Visibility = Visibility.Hidden;
            }
            else
            {
                tbHint.Visibility = Visibility.Visible;
            }
        }
    }
}
