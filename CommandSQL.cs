using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon
{
    internal class CommandSQL
    {
        public string connStr = "server=localhost;username=root;password=;database=databasedesign";
        public MySqlConnection conn;
        public string Query;
        public CommandSQL()
        {
            conn = new MySqlConnection(this.connStr);
        }
        public void ChackPeople(string firstname, string lastname)
        {
            //this.Query = $"SELECT EXISTS (SELECT 1 FROM people WHERE firstName='{firstname}'AND lastName='{lastname}'";
            this.Query = "SELECT * FROM people;";
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(Query, conn);
                //var ensver = comm.ExecuteNonQuery();
                var reade = comm.ExecuteReader();
                while (reade.Read()) { Console.WriteLine(reade.GetString("firstName")); }
                //GetString("firstName"));
                comm.Clone();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { conn.Close(); }
        }
    }
}
