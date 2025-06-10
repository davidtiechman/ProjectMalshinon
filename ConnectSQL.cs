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
        public void AddedPeople(string firstname, string lastname)
        {
            string secretcode = GetCode();
            try {
                conn.Open();
                    this.Query = $"INSERT INTO people (firstName,lastName,secret_code,type) VALUES ('{firstname}','{lastname}','{secretcode}','reporter')";
                    MySqlCommand comm = new MySqlCommand(Query, conn);
                    comm.ExecuteNonQuery();        
                
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            finally { this.conn.Close(); }
        
        }
        public bool ChackSecretC(string secretcode)
        {
            bool notexists = true;
            try
            {
                conn.Open();
                this.Query = $"SELECT EXISTS (SELECT 1 FROM people WHERE secret_code = '{secretcode}');";
                MySqlCommand comm = new MySqlCommand(Query, conn);
                var res = comm.ExecuteScalar();
                int re = Convert.ToInt32(res);
                if (re == 1)
                    notexists = false;
                return notexists;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { conn.Close(); }
            return notexists;

        }
        public string GetCode()
        {
            string[] chars = new string[] { "1", "c", "5", "j", "9", "7", "a", "S","c", "3" };
            Random random = new Random();
            bool ifexsist = true;
            string secretcode = "";
            while (ifexsist)
            {
                secretcode = null;
                for (int i = 0; i < 7; i++)
                {
                    secretcode += chars[random.Next(chars.Length)];
                }
                if (ChackSecretC(secretcode) == true)
                    ifexsist = false;
            }
            return secretcode;
        }
    }
}
