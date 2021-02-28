using Api.FoodTruck.Core.LocationApi.Models;
using Api.FoodTruck.Core.LocationApi.Utilities;
using Api.FoodTruck.DataManagement.DotNetCore.Location.Definition.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.FoodTruck.Core.LocationApi.Converters
{
    public static class LocationConverter
    {
        internal static Location Convert(LocationRequest locationRequest)
        {
            var currentLoc = locationRequest.Location;
            return new Location
            {
                StreetNumber = currentLoc.StreetNumber.IgnoreNull(),
                StreetName = currentLoc.StreetName.IgnoreNull(),
                City = currentLoc.City.IgnoreNull(),
                State = currentLoc.State.IgnoreNull(),
                ZipCode = currentLoc.ZipCode.IgnoreNull(),
                FullAddress = currentLoc.FullAddress.IgnoreNull(),
                LocationDescription = currentLoc.LocationDescription.IgnoreNull(),
                InsertTimeStamp = DateTime.Now
            };
        }

        internal static GetLocationResponse ConvertToReponse(Location latestLoc)
        {
            var response = new GetLocationResponse
            {
                Location = new LocationInfo
                {
                    StreetNumber = latestLoc.StreetNumber.IgnoreNull(),
                    StreetName = latestLoc.StreetName.IgnoreNull(),
                    City = latestLoc.City.IgnoreNull(),
                    State = latestLoc.State.IgnoreNull(),
                    ZipCode = latestLoc.ZipCode.IgnoreNull(),
                    FullAddress = latestLoc.FullAddress.IgnoreNull(),
                    LocationDescription = latestLoc.LocationDescription.IgnoreNull()
                }
            };
            return response;
        }
    }
}
