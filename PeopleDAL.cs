using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon
{
    internal class PeopleDAL
    {
        public string connStr = "server=localhost;username=root;password=;database=databasedesign";
        public MySqlConnection connect;
        public MySqlCommand command;
        public string Query;
        public PeopleDAL()
        {
           this.connect = new MySqlConnection(this.connStr);
        }
        public bool ChackPeople(string firstname, string lastname)
        {
            bool exist = false;
            this.Query = $"SELECT EXISTS (SELECT 1 FROM people WHERE firstName = '{firstname}' AND lastName = '{lastname}');";
            try {                 if (connect.State != ConnectionState.Open)
                this.connect.Open();
                 this.command = new MySqlCommand(Query, connect);
                var reade = command.ExecuteScalar();
                int result = Convert.ToInt32(reade);
                //Console.WriteLine(result);
                if (result == 1)
                    exist = true;
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { this.connect.Close(); }
            return exist;
        }
        public void AddPeople(string firstname, string lastname,string type)
        {
            string secretcode = GetCode();
            try {
                connect.Open();
                    this.Query = $"INSERT INTO people (firstName,lastName,secret_code,type) VALUES ('{firstname}','{lastname}','{secretcode}','{type}')";
                    this.command = new MySqlCommand(Query, connect);
                    command.ExecuteNonQuery();        
                
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            finally { this.connect.Close(); }
        
        }
        public bool ChackSecretC(string secretcode)
        {
            bool notexists = true;
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                this.Query = $"SELECT EXISTS (SELECT 1 FROM people WHERE secret_code = '{secretcode}');";
                MySqlCommand comm = new MySqlCommand(Query, connect);
                var res = comm.ExecuteScalar();
                int re = Convert.ToInt32(res);
                if (re == 1)
                    notexists = false;
                return notexists;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connect.Close(); }
            return notexists;

        }
        public string GetCode()
        {
            string[] chars = new string[] { "1", "C", "5", "8", "9", "7", "3", "S","4", "3" };
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
