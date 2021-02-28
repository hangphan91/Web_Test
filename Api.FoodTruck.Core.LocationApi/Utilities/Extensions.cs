using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.FoodTruck.Core.LocationApi.Utilities
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
