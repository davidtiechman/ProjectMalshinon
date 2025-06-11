using ProjectMalshinon;
using MySql.Data.MySqlClient;

namespace projectMalshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = Menu.instance;
            menu.PrintMenu();
            //ConnectSQL conn = new ConnectSQL();
            //conn.ChackPeople("david","teichman");
            //Console.WriteLine(conn.GetCode());
            //conn.AddedPeople("jon", "tramp");
            //IntelReportsDAL report = new IntelReportsDAL();
            //report.ChackPeople("John", "Smith");
            //report.AddIntelReports();
            //report.GetColumn(1, "num_reports");
            //report.GetColumn(1, "num_reports");
            //report.ChackPotentialAtent(7);
            //report.ChackPotentialThragt(5);
            //report.FindId(["David", "Wilson"]);
        }
    }
}
