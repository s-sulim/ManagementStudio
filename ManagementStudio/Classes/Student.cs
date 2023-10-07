using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementStudio.Classes
{
    public class Student
    {
        private static MySQLite MySQL = new MySQLite();
        public  int StudentID { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public  string PhoneNumber { get; set; }
        public  string Major { get; set; }

        public Student(int id, string firstname, string lastName, string email, string phoneNumber, string major)
        {
            StudentID = id;
            FirstName = firstname;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
        }
        public Student(string firstname, string lastName, string email, string phoneNumber, string major)
        {
            if (!StudentExists(lastName))
            {
                FirstName = firstname;
                LastName = lastName;
                Email = email;
                PhoneNumber = phoneNumber;
                Major = major;
                MySQL.ExecuteNonQuery($"INSERT INTO Students (FirstName, LastName, Email, PhoneNumber, Major) VALUES ('{FirstName}','{LastName}', '{Email}', '{PhoneNumber}', '{Major}');");
            }
        }
        private bool StudentExists(int userID)
        {
            if (MySQL.ExecuteQuery($"SELECT * FROM Students WHERE StudentID = {StudentID};").Rows.Count == 0)
                return false;
            else
                return true;
        }
        private bool StudentExists(string username)
        {
            if (MySQL.ExecuteQuery($"SELECT * FROM Students WHERE FirstName = '{username}';").Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static List<Student> GetAllStudents()
        {
            var res = MySQL.ExecuteQuery($"SELECT * FROM Students;");
            List<Student> students = new List<Student>();
            foreach (DataRow row in res.Rows)
            {
                students.Add(new Student(Convert.ToInt32(row["StudentID"]), Convert.ToString(row["FirstName"]), Convert.ToString(row["LastName"]), Convert.ToString(row["Email"]), Convert.ToString(row["PhoneNumber"]), Convert.ToString(row["Major"])));
            }
            return students;
        }
    }
}
