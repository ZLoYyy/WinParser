using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinParser.Tools
{
    internal class DB
    {
        private static MySqlConnection MySQLDBConnect(string serverName, string userName, string password, string dbName)
        {
            string connStr = string.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; connection timeout=50;Character Set=utf8",
                        serverName, userName, password, dbName);
            MySqlConnection connection = new MySqlConnection(connStr);

            return connection;
        }

        public static MySqlConnection GetParam()
        {
            string serverName = "31.31.196.204";
            string userName = "u0476674_bs_rees";
            string dbName = "u0476674_bs_reestr";
            string password = "11Reestr11";

            /*string serverName = Properties.Settings.Default.ServerName;
            string userName = Properties.Settings.Default.UserName;
            string dbName = Properties.Settings.Default.DbName;
            string password = Properties.Settings.Default.Password;*/

            return MySQLDBConnect(serverName, userName, password, dbName);
        }

        public static MySqlConnection GetParamADM()
        {
            string serverName = "31.31.196.204";
            string userName = "u0476674_adm";
            string dbName = "u0476674_sheduleadm";
            string password = "11Ltyxbr11";

            string connStr = string.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; connection timeout=50;Character Set=utf8",
                        serverName, userName, password, dbName);
            MySqlConnection connection = new MySqlConnection(connStr);

            return connection;
        }
    }
}
