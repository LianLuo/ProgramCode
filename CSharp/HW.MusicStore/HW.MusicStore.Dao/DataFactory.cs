using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private static readonly string DbType = string.Empty;
        static DataFactory()
        {
            string db = ConfigurationManager.AppSettings["db"].ToLower();
            string connstr = ConfigurationManager.AppSettings["connstr"];
            DbType = db;
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

        public static IDbDataParameter GetParameter(string key, object value)
        {
            switch (DbType)
            {
                case "mysql":
                    return null;
                case "sqlite":
                    return new SQLiteParameter(key,value);
                case "mssql":
                    return null;
                default:
                    throw new Exception("database setting occurr.");
            }
        }

        public static IDbDataParameter[] GetParameters(int length)
        {
            switch (DbType)
            {
                case "mysql":
                    return null;
                case "sqlite":
                    return new IDbDataParameter[length];
                case "mssql":
                    return null;
                default:
                    throw new Exception("database setting occurr.");
            }
        }
    }
}
