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
        private readonly int ID;
        public readonly string Username;
        public readonly string Password;
        public readonly string CreationDate;
        public readonly Permissions PermissionLevel;
        private static MySQLite MySQL = new MySQLite();

        private User(int ID, string Username, string Password, string CreationDate, Permissions PermissionLevel)
        {
            if (!UserExistsWithID(ID))
            {
                this.ID = ID;
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
            if (!UserExistsWithUsername(Username))
            {
                MySQL.ExecuteNonQuery($"INSERT INTO Users (Username, Password, CreationDate, PermissionLevel) VALUES ('{Username}','{Password}','{DateTime.Now.ToString()}',{(int)PermissionLevel})");
            }
        }
        public User GetUserByID(int ID)
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
        private bool UserExistsWithID(int userID)
        {
            if (MySQL.ExecuteQuery($"SELECT * FROM Users WHERE UserID = {ID};").Rows.Count == 0)
                return false;
            else
                return true;
        }
        private bool UserExistsWithUsername(string username)
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
