using System.Data.SqlClient;

namespace QLNhapTinh
{
    class ConnectionDB
    {
        public static SqlConnection getNetwork()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + AppConfig.Server + ";Network Library=DBMSSOCN;"
             + "Initial Catalog=" + AppConfig.Database + ";User ID=" + AppConfig.Username + ";Password=" + AppConfig.Password + ";";
            return conn;
        }
        public static SqlConnection getOffLine()
        {
            /*SqlConnection conn = new SqlConnection();
                      conn.ConnectionString = @"Data Source="+AppConfig.Serveroff+";"
                      + @"AttachDbFilename=|DataDirectory|\" + AppConfig.Databaseoff + ".mdf;"
                      + "Integrated Security=True;User Instance=True";*/
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + AppConfig.Serveroff + ";"
            + "Initial Catalog=" + AppConfig.Databaseoff + ";"
            + "Integrated Security=True";
            return conn;
        }
    }
}
//conn.ConnectionString = "Data Source=" + AppConfig.Serveroff + ";"
//               + "Initial Catalog=" + AppConfig.Databaseoff + ";"
//               + "Integrated Security=True";