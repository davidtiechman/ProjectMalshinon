using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projectMalshinon.PEOPLE;

namespace projectMalshinon.REPORTER
{
    internal class IntelReportsDAL : PeopleDAL
    {
        public string Text;
        public string Id_Reporter;
        public void AddInter(string id, string text)
        {
            Text = text;
            Id_Reporter = id;

        }
        public void AddIntelReports()
        {
            Console.WriteLine("Plese enter uor first name");
            string firstNrepor = Console.ReadLine();
            Console.WriteLine("Plese enter uor last name");
            string lastNrepor = Console.ReadLine();
            Console.WriteLine("Plese enter the intel");
            string text = Console.ReadLine();
            if(! ChackPeople(firstNrepor, lastNrepor))
            {
                string type = Console.ReadLine();
                AddPeople(firstNrepor, lastNrepor,"reporter");
            }
            int id_reporter = FindId([firstNrepor, lastNrepor]);
            string[] fullnameTerger = FindTarget(text);
            if (!ChackPeople(fullnameTerger[0], fullnameTerger[1]))
            {
                AddPeople(fullnameTerger[0], fullnameTerger[1],"target");
            }
            int id_target = FindId(fullnameTerger);
            Query = $"INSERT INTO intelreports (reporter_id,targer_id,text) VALUES ({id_reporter},{id_target},'{text}');";
            try
            {
                connect.Open();
                 command = new MySqlCommand(Query, connect);
                command.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connect.Close(); }
            UpdateNumFlusOne("num_reports", id_reporter);
            UpdateNumFlusOne("num_mentions", id_target);
            ChackPotentialAtent(id_reporter);
            ChackPotentialThragt(id_target);
            Console.WriteLine("The update was successfully updated.");
        }
        public string[] FindTarget(string text)
        {
            string[] arrayText = text.Split(" ");
            string[] names = new string[2];
            string fullname = "";
            for (int i = 0; i < arrayText.Length; i++)
            {
                if (char.IsUpper(arrayText[i][0]))
                {
                    fullname += arrayText[i];
                    fullname += " ";
                }
            }
            fullname = fullname.Remove(fullname.Length - 1);
            names = fullname.Split(" ");
            return names;

        }
        public int FindId(string[] arrfullnames)
        {
            string firstname = arrfullnames[0];
            string lastname = arrfullnames[1];
            Query = $"SELECT Id FROM people WHERE firstName = '{firstname}' AND lastName = '{lastname}';";
            int id = 0;
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                 command = new MySqlCommand(Query, connect);
                var reade = command.ExecuteScalar();
                id = Convert.ToInt32(reade);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { connect.Close(); }
            return id;
        }
        public void UpdateNumFlusOne(string type_id, int id)
        {
            Query = $"UPDATE people SET {type_id} = {type_id} +1 WHERE Id = {id} ";
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                command = new MySqlCommand(Query, connect);
                command.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connect.Clone(); }
        }
        public int GetColumn(int id, string column)
        {
            int num = 0;
            Query = $"SELECT {column} FROM people WHERE Id = {id};";
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                command = new MySqlCommand(Query, connect);
                var reade = command.ExecuteScalar();
                num = Convert.ToInt32(reade);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connect.Close(); }
            Console.WriteLine(num);
            return num;
        }
        public void ChackPotentialAtent(int id)
        { 
            int num = GetColumn(id, "num_reports");
            if (num >= 10) {
                try
                {
                    if (connect.State != ConnectionState.Open)
                        connect.Open();
                    Query = $"UPDATE people SET type = 'potential_agent' WHERE Id = {id};";
                    command = new MySqlCommand(Query, connect);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { connect.Close(); }
            }
            else Console.WriteLine("not potential for agent");
        }
        public void ChackPotentialThragt(int id)
        {
            int num = GetColumn(id, "num_mentions");
            if (num >= 20)
            {
                try
                {
                    if (connect.State != ConnectionState.Open)
                        connect.Open();
                    Query = $"UPDATE people SET type = 'potential_threat' WHERE Id = {id};";
                    command = new MySqlCommand(Query, connect);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { connect.Close(); }
            }
            else Console.WriteLine("not potential for threat");

        }
    } 
}
