using Api.FoodTruck.DataManagement.Location.Entities;
using Api.FoodTruck.DataManagement.Utilities;
using LocationWithQueries.Queries;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InsertNewLocation(new Location { FullAddress = "FullAddress" });
        }
        public static void InsertNewLocation(Location location)
        {
            string myConnectionString = SqlConnectionUtility.GetSqlConnection();
           

            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                var con = new MySqlConnection(myConnectionString);
                con.Open();

                //var insert = Queries.InsertNewLocation;

                // var cmd = new MySqlCommand(insert, con);

                //var parameters = PopulateParameters(location);
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddRange(parameters.ToArray());

                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected != 1)
                //{
                //    throw new Exception();
                //}
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static List<MySqlParameter> PopulateParameters(Location location)
        {
            List<MySqlParameter> Params = new List<MySqlParameter>
            {
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.StreetNumber,
                        ParameterName = "@StreetNum"
                    },
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.StreetName,
                        ParameterName = "@StreetName"
                    },
                     new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.City,
                        ParameterName = "@City"
                    },
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.State,
                        ParameterName = "@State"
                    },
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.ZipCode,
                        ParameterName = "@ZipCode"
                    },
                     new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.FullAddress,
                        ParameterName = "@FullAddress"
                    },
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.LocationDescription,
                        ParameterName = "@LocationDescription"
                    },
                    new MySqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        Value = location.InsertTimeStamp,
                        ParameterName = "@InsertTimeStamp"
                    }
            };
            return Params;
        }
    }
}
