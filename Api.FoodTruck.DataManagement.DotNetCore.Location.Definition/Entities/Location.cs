using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.FoodTruck.DataManagement.DotNetCore.Location.Definition.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string StreetNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string FullAddress { get; set; }
        public string LocationDescription { get; set; }
        public string ZipCode { get; set; }
        public DateTime InsertTimeStamp { get; set; }
    }
}
