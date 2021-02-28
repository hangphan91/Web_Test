using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationWithQueries.Queries;
using System.Data;
using Api.FoodTruck.DataManagement.Utilities;

namespace LocationWithQueries.DataAccessors
{
    public class LocationDa
    {
        public void InsertNewLocation(LocationWithQueries.Models.Location location)
        {

            string myConnectionString = SqlConnectionUtility.GetSqlConnection();
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                var con = new MySqlConnection(myConnectionString);
                con.Open();

                var insert = Queries.Queries.InsertNewLocation;

                var cmd = new MySqlCommand(insert, con);

                var parameters = PopulateParameters(location);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters.ToArray());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    throw new Exception();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private static List<MySqlParameter> PopulateParameters(Models.Location location)
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
