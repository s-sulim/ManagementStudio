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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementStudio.UserControls
{
    /// <summary>
    /// Interaction logic for UsersGridView.xaml
    /// </summary>
    public partial class UsersGridView : UserControl
    {
        private MySQLite mySQL;
        public UsersGridView()
        {
            InitializeComponent();
            mySQL = new MySQLite();
        }
       
        private void ReloadUsers()
        {
            gvUsers.Items.Clear();
            foreach (User user in User.GetAllUsers())
            {
                gvUsers.Items.Add(user);
            }
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadUsers();
        }
    }
}
