using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementStudio.Classes
{
   public class MySQLite
    {
        private string connString;
        private SQLiteConnection conn;
        public MySQLite()
        {
            connString = "Data Source=myDB.db;Version=3;";
            conn = new SQLiteConnection(connString);
            conn.Open();
        }
        public MySQLite(string connectionString)
        {
            connString = connectionString;
            conn = new SQLiteConnection(connString);
            conn.Open();
        }
        public void ExecuteNonQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
