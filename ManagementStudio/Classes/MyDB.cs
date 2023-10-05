using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementStudio.Classes
{
    public class MyDB
    {
        private readonly string qrInitStudents = "CREATE TABLE IF NOT EXISTS Students (StudentID INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, PhoneNumber TEXT, Major TEXT);";
        private readonly string qrInitUser = "CREATE TABLE IF NOT EXISTS Users (UserID INTEGER PRIMARY KEY, Username TEXT, Password TEXT, CreationDate TEXT, PermissionLevel INTEGER);";
        public MyDB()
        {
            MySQLite mySQLite = new MySQLite();
            mySQLite.ExecuteNonQuery(qrInitStudents);
            mySQLite.ExecuteNonQuery(qrInitUser);
        }
    }
}
