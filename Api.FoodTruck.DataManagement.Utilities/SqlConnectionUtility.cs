
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FoodTruck.DataManagement.Utilities
{
    public static class SqlConnectionUtility
    {
        public static string GetSqlConnection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();

            string myConnectionString;
            var server = "sql335.main-hosting.eu";
            var user = "u323743937_funnyluv122";
            var password = "SQLmatkhau1";
            var database = "u323743937_LinhFoodTruck";
            myConnectionString = $"server={server};user={user};password={password};database={database};";
           
            conn_string.Server = server;
            conn_string.Port = 3306;
            conn_string.UserID = user;
            conn_string.Password = password;
            conn_string.Database = database;

            return conn_string.ToString();
        }
    }
}
