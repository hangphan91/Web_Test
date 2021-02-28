using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.FoodTruck.Core.LocationApi.Models
{
    public class InsertLocationResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        public InsertLocationResponse(string msg, bool success)
        {
            Message = msg;
            Success = success;
        }
        public InsertLocationResponse()
        {
        }
    }
}