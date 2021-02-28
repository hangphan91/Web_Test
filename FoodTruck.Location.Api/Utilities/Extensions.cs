using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Location.Api.Utilities
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
