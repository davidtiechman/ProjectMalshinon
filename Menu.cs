using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMalshinon;
using ZstdSharp.Unsafe;

namespace projectMalshinon
{
    internal class Menu
    {
        public PeopleDAL peopleDAL = new PeopleDAL();
        public IntelReportsDAL intelreportsDAL = new IntelReportsDAL();
        private static Menu Instance;
        private string HomePage = "Hello! " + "Please select an option" + " To enter a report, enter 1";
        private Menu() { }
        public static Menu instance
        {
            get
            {
                if (Instance == null)
                    Instance = new Menu();
                return Instance;
            }
        }
        public void PrintMenu()
        {
            Console.WriteLine(this.HomePage);
            Option();
        }
        public void Option() {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Pleas enter an option");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        intelreportsDAL.AddIntelReports();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "9":
                        exit = true;
                        Console.WriteLine("You have successfully logged out");
                        break;
                }

            }   
            
        }
        
    }
}
