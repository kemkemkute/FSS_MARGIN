using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace DAO
{
    public class DataProvider
    {
        // CHuỗi kết nối
        public static string connectionString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-K1OVBF4)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE))); User Id = thuylinhMargin; password = 12345; ";

        // Lấy kết nối đến DB
        public static OracleConnection GetOracleConnection()
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(connectionString);
                oracleConnection.Open();

                return oracleConnection;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối, vui lòng kiểm tra lại đường truyền \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn
        /// </summary>
        /// <param name="oracleCmd"></param>
        /// <returns></returns>
        public static OracleDataReader GetOracleDataReader(OracleCommand oracleCmd)
        {
            try
            {
                OracleDataReader oracleDataReader;
                oracleCmd.Connection = GetOracleConnection();
                oracleDataReader = oracleCmd.ExecuteReader();

                return oracleDataReader;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh non query
        /// </summary>
        /// <param name="oracleCommand"></param>
        /// <returns></returns>
        public static bool ExcuteNonQuery(OracleCommand oracleCommand)
        {
            try
            {
                oracleCommand.Connection = GetOracleConnection();
                oracleCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
