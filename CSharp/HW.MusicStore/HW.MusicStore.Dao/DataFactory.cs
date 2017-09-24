using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HW.MusicStore.Dao
{
    public static class DataFactory
    {
        private static readonly InternalDbSession instance = null;

        static DataFactory()
        {
            string db = ConfigurationManager.AppSettings["db"].ToLower();
            string connstr = ConfigurationManager.AppSettings["connstr"];

            switch (db)
            {
                case "mysql":
                    instance = new InternalDbSession(new MySqlConnection(connstr));
                    break;
                case "sqlite":
                    instance = new InternalDbSession(new SQLiteConnection(connstr));
                    break;
                case "mssql":
                    instance = new InternalDbSession(new SqlConnection(connstr));
                    break;
                default:
                    throw new Exception("database setting occurr.");
            }
        }

        public static InternalDbSession CreateDatabase()
        {
            return instance;
        }
    }
}
