using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon
{
    internal class ConnectSQL
    {
        public string connStr = "server=localhost;username=root;password=;database=databasedesign";
        public MySqlConnection conn;
        public string Query;
        public ConnectSQL()
        {
           this.conn = new MySqlConnection(this.connStr);
        }
        public void ChackPeople(string firstname, string lastname)
        {
            this.Query = $"SELECT EXISTS (SELECT 1 FROM people WHERE firstName = '{firstname}' AND lastName = '{lastname}');";
            //this.Query = "SELECT * FROM people;";

            try
            {
                this.conn.Open();
                MySqlCommand comm = new MySqlCommand(Query, conn);
                var result = comm.ExecuteScalar();
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { this.conn.Close(); }
        }
        public void AddedPeople(string firstname, string lastname, string secretcode)
        {
            try {
                conn.Open();
                this.Query = $"INSERT INTO people (firstName,lastName,secret_code) VALUES ('{firstname}','{lastname}','{secretcode}')";
                MySqlCommand comm = new MySqlCommand(Query, conn);
                comm.ExecuteNonQuery();
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            finally { this.conn.Close(); }
        
        }
        public void ChecSecretC()
        {
            try
            {

            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
