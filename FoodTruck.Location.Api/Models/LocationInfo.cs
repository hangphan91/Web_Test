using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruck.Location.Api.Models
{
    public class LocationInfo
    {
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("fullAddress")]
        public string FullAddress { get; set; }

        [JsonProperty("currentLocation")]
        public string LocationDescription { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
    }
}