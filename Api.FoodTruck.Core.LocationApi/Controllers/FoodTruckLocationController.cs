using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Api.FoodTruck.Core.LocationApi.Attributes;
using Api.FoodTruck.Core.LocationApi.Converters;
using Api.FoodTruck.Core.LocationApi.Engines;
using Api.FoodTruck.Core.LocationApi.Models;
using Api.FoodTruck.DataManagement.DotNetCore.Location.Persistence.DataAccessors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Api.FoodTruck.Core.LocationApi.Controllers
{
    [Route("api/FoodTruckLocation")]
    [ApiController]
    public class FoodTruckLocationController : ControllerBase
    {
        [Route("post/currentLocation")]
        [HttpPost]
        public virtual IHttpActionResult SaveCurrentLocation([FromBody] LocationRequest locationRequest)
        {
            var response = new InsertLocationResponse();
            var requestValidate = new ValidateRequestEngine(locationRequest);
            try
            {
                if (requestValidate.IsValid)
                {
                    LocationDa da = new LocationDa();
                    da.SaveChanges(LocationConverter.Convert(locationRequest));
                    response.Success = true;
                    response.Message = "Saved Location.";
                    da.Dispose();
                }
                else
                {
                    response.Success = false;
                    response.Message = requestValidate.Message;
                    return new HttpActionResult(HttpStatusCode.BadRequest, response);
                }
            }
            catch (Exception ex)
            {

            }
            return new HttpActionResult(HttpStatusCode.OK, response);
        }

        [Route("get/currentLocation")]
        [RequiresHttps]
        [System.Web.Http.HttpGet]
        public virtual IHttpActionResult GetCurrentLocation()
        {
            var response = new GetLocationResponse();
            try
            {
                LocationDa da = new LocationDa();
                var latestLoc = da.GetLatestLocation();
                var location = LocationConverter.ConvertToReponse(latestLoc);
                var json = JsonConvert.SerializeObject(location, new JsonSerializerSettings { Formatting = Formatting.None });
                response = JsonConvert.DeserializeObject<GetLocationResponse>(json);

                da.Dispose();
            }
            catch (Exception ex)
            {

            }
            return new HttpActionResult(HttpStatusCode.OK, response);
        }
    }
}
