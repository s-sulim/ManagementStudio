using ManagementStudio.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ManagementStudio.Forms
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
      
        public AddStudentWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbMajor.ItemsSource = Constants.Majors;
            cbMajor.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student(ctbName.Text, ctbLastName.Text, ctbEmail.Text, ctbPhoneNumber.Text, cbMajor.Text);
            this.DialogResult = true;
        }

        private void ctbLastName_TouchLeave(object sender, TouchEventArgs e)
        {
            ctbEmail.Text = ctbName.Text.ToLower() + "." + ctbLastName.Text.ToLower() + "@gmail.com";
        }
    }
}
