using System;

namespace SqlConnectionUtility
{
    public static class SqlConnectionUtility
    {
        public static string GetSqlConnection()
        {
            string myConnectionString;
            var server = "45.84.204.1";
            var user = "u323743937_funnyluv122";
            var password = "Khongdoi1234";
            var database = "u323743937_LinhFoodTruck";
            myConnectionString = $"server={server};user={user};password={password};database={database};";
            return myConnectionString;
        }

    }
}
