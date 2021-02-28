using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.FoodTruck.Core.LocationApi.Models
{
    public class LocationRequest
    {
        [JsonProperty("Location")]
        public LocationInfo Location { get; set; }
    }
}