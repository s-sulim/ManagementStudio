using ManagementStudio.Classes;
using ManagementStudio.Forms;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementStudio.UserControls
{
    /// <summary>
    /// Interaction logic for StudentsGridView.xaml
    /// </summary>
    public partial class StudentsGridView : UserControl
    {
        private MySQLite mySQL;
        public StudentsGridView()
        {
            InitializeComponent();
            mySQL = new MySQLite();
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            if (addStudentWindow.ShowDialog() == true)
                 ReloadStudents();
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            int studentId = ((Student)gvStudents.SelectedValue).StudentID;
            string qr = "DELETE FROM Students WHERE StudentID = " + studentId;
            mySQL.ExecuteNonQuery(qr);
            ReloadStudents();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadStudents();
        }
        private void ReloadStudents()
        {
            gvStudents.Items.Clear();
            foreach (Student student in Student.GetAllStudents())
            {
                gvStudents.Items.Add(student);
            }
        }
    }
}
