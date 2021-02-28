using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruck.Location.Api.Utitlities
{
    public static class Extensions
    {
        public static string IgnoreNull(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj) ? string.Empty : obj;
        }
        public static bool IsNull(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj);
        }
    }
}