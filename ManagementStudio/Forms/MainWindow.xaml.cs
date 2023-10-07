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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDB myDB;
        private MySQLite mySQL;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            myDB = new MyDB();
            mySQL = new MySQLite();
            User adminUser = new User("admin","12345", Constants.Permissions.Admin);
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            if (addStudentWindow.ShowDialog() == true)
            {
                gvStudents.Items.Clear();
                foreach (Student student in Student.GetAllStudents())
                {
                    gvStudents.Items.Add(student);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            foreach (Student student in Student.GetAllStudents())
            {
                gvStudents.Items.Add(student);
            }
        }
    }
}
