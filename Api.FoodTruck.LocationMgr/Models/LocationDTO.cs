using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FoodTruck.LocationMgr.Models
{
    public class LocationDTO : BaseDTO
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FullAddress { get; set; }
        public string LocationDescription { get; set; }
        public string ZipCode { get; set; }
    }
}
