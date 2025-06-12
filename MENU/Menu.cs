using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectMalshinon.PEOPLE;
using projectMalshinon.REPORTER;
using ZstdSharp.Unsafe;

namespace projectMalshinon.MENU
{
    internal class Menu
    {
        public PeopleDAL peopleDAL = new PeopleDAL();
        public IntelReportsDAL intelreportsDAL = new IntelReportsDAL();
        private static Menu Instance;
        private string HomePage = "Hello!\nHere is the menu:\nTo enter a report, enter 1\nFor administrator login, enter 2\nTo exit enter 9\nPlease select an option:";
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
            Console.WriteLine(HomePage);
            Option();
        }
        public void Option() {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\n\nPleas enter an option");
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
