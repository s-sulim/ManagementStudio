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
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {
        private string _hint;
        public string Hint
        {
            get { 
                return _hint;
            }
            set { 
                _hint = value;
                OnPropertyChanged(nameof(Hint));
            }
        }
        public string Text
        {
            get
            {
                return tbInput.Text;
            }
            set
            {
                tbInput.Text = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ClearableTextBox()
        {
            InitializeComponent();
            this.PropertyChanged += ClearableTextBox_PropertyChanged;
        }
        private void ClearableTextBox_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Hint))
                tbHint.Text = Hint;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Clear();
        }
        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbInput.Text))
            {
                tbHint.Visibility = Visibility.Hidden;
            }
            else
            {
                tbHint.Visibility = Visibility.Visible;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
