using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementStudio
{
    public static class Constants
    {
        public static List<String> Majors = new List<string>
        {
            "Computer Science",
            "Math",
            "Physics",
            "Philosophy",
            "Language studies",
            "Economics",
            "Politics",
            "Law"
        };
        public enum Permissions
        {
            NormalUser = 0,
            Manager = 1,
            Admin = 2,
        }
    }
}
