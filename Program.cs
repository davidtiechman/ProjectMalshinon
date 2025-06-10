using ProjectMalshinon;
using MySql.Data.MySqlClient;

namespace projectMalshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectSQL conn = new ConnectSQL();
            //conn.ChackPeople("david","teichman");
            //Console.WriteLine(conn.GetCode());
            conn.AddedPeople("jon", "tramp");
        }
    }
}
