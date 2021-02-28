using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.FoodTruck.FoodTruckApi.Models
{
    public enum ErrorType
    {
        ResonseError,
        RequestError
    }
    public class Error
    {
        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public Error( ErrorType errorType, string errorMessage)
        {
            ErrorType = ErrorType;
            ErrorMessage = errorMessage;
        }
    }
}