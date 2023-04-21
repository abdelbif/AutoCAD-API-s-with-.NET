using Autodesk.AutoCAD.Runtime;
using System.Data.SqlClient;


namespace DotNet_Autocad
{
    public static class DBUtil
    {
        [CommandMethod("DBRun")]
        public static void DBRun()
        {
            Main main = new Main();
            main.ShowDialog();
        }
        public static SqlConnection GetConnection()
        {
            string connStr = Settings1.Default.connStr;
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }
    }
}
