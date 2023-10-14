using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static ManagementStudio.Constants;

namespace ManagementStudio.Classes
{
    public class User
    {
        private int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CreationDate { get; set; }
        public Permissions PermissionLevel { get; set; }
        private static MySQLite MySQL = new MySQLite();

        private User(int ID, string Username, string Password, string CreationDate, Permissions PermissionLevel)
        {
            if (!UserExists(ID))
            {
                this.UserID = ID;
                this.Username = Username;
                this.Password = Password;
                this.CreationDate = CreationDate;
                this.PermissionLevel = PermissionLevel;
            }
        }
        /// <summary>
        /// Creates new user and inserts int into the DB
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="PermissionLevel"></param>
        public User(string Username, string Password, Permissions PermissionLevel)
        {
            if (!UserExists(Username))
            {
                MySQL.ExecuteNonQuery($"INSERT INTO Users (Username, Password, CreationDate, PermissionLevel) VALUES ('{Username}','{Password}','{DateTime.Now.ToString()}',{(int)PermissionLevel})");
            }
        }
        public static User GetUserByID(int ID)
        {
            var res = MySQL.ExecuteQuery($"SELECT * FROM Users WHERE UserID = {ID};");
            if (res != null && res.Rows.Count > 0)
            {
                Constants.Permissions Permission = Permissions.NormalUser;
                switch (res.Rows[0]["PermissionLevel"])
                {
                    case 0:
                        Permission = Constants.Permissions.NormalUser;
                        break;
                    case 1:
                        Permission = Constants.Permissions.Manager;
                        break;
                    case 2:
                        Permission = Constants.Permissions.Admin;
                        break;
                }
                User user = new User(ID, Convert.ToString(res.Rows[0]["Username"]), Convert.ToString(res.Rows[0]["Password"]), Convert.ToString(res.Rows[0]["CreationDate"]), Permission);
                return user;
            }
            return null;
        }
        public static User GetUserByUsername(string Username)
        {
            var res = MySQL.ExecuteQuery($"SELECT * FROM Users WHERE Username = '{Username}';");
            if (res != null && res.Rows.Count > 0)
            {
                Constants.Permissions Permission = Permissions.NormalUser;
                int userPermissionInt = Convert.ToInt32(res.Rows[0]["PermissionLevel"]);
                switch (userPermissionInt)
                {
                    case 0:
                        Permission = Constants.Permissions.NormalUser;
                        break;
                    case 1:
                        Permission = Constants.Permissions.Manager;
                        break;
                    case 2:
                        Permission = Constants.Permissions.Admin;
                        break;
                }
                User user = new User(Convert.ToInt32(res.Rows[0]["UserID"]), Convert.ToString(res.Rows[0]["Username"]), Convert.ToString(res.Rows[0]["Password"]), Convert.ToString(res.Rows[0]["CreationDate"]), Permission);
                return user;
            }
            return null;
        }
        private bool UserExists(int userID)
        {
            if (MySQL.ExecuteQuery($"SELECT * FROM Users WHERE UserID = {UserID};").Rows.Count == 0)
                return false;
            else
                return true;
        }
        private bool UserExists(string username)
        {
            if (MySQL.ExecuteQuery($"SELECT * FROM Users WHERE Username = '{username}';").Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static List<User> GetAllUsers()
        {
            var res = MySQL.ExecuteQuery($"SELECT * FROM Users;");
            List<User> users = new List<User>();    
            foreach (DataRow row in res.Rows)
            {
                users.Add(new User(Convert.ToInt32(row["UserID"]), Convert.ToString(row["Username"]), Convert.ToString(row["Password"]), Convert.ToString(row["CreationDate"]), (Constants.Permissions)Convert.ToInt32(row["PermissionLevel"])));
            }
            return users;
        }
    }
}
