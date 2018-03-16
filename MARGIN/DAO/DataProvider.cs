using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DAO
{
    public class DataProvider
    {
        // CHuỗi kết nối
        public static string connectionString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-K1OVBF4)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE))); User Id = thuylinhMargin; password = 12345; ";

        // Lấy kết nối đến DB
        public static OracleConnection GetOracleConnection()
        {
            OracleConnection oracleConnection = new OracleConnection(connectionString);
            oracleConnection.Open();
            return oracleConnection;
        }

        // Thực thi câu lệnh truy vấn
        public static OracleDataReader GetOracleDataReader(OracleCommand oracleCommand)
        {
            try
            {
                oracleCommand.Connection = GetOracleConnection();

                return oracleCommand.ExecuteReader();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }



    }
}
