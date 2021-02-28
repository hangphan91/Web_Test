using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationWithQueries.Models
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
