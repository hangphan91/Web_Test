

namespace LocationWithQueries.Queries
{
    public static class Queries
    {
        public static string InsertNewLocation = @"
                                                        INSERT INTO 
                                                        `Locations` 
                                                        (`StreetNumber`,
                                                        `StreetName`, 
                                                        `City`,
                                                        `State`,
                                                        `ZipCode`,
                                                        `FullAddress`,
                                                        `LocationDescription`,
                                                        `InsertTimeStamp`)
                                                        VALUES
                                                        (@StreetNum,
                                                         @StreetName,
                                                         @City,
                                                         @State,
                                                         @ZipCode,
                                                         @FullAddress, 
                                                         @LocationDescription,
                                                         @InsertTimeStamp
                                                         );
                                                    ";
    }
}
