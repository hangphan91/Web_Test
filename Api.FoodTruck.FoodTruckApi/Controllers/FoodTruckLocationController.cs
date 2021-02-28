using Api.FoodTruck.DataManagement.Loation.Persistence.DataAccessors;
using Api.FoodTruck.FoodTruckApi.Attributes;
using Api.FoodTruck.FoodTruckApi.Converters;
using Api.FoodTruck.FoodTruckApi.Engine;
using Api.FoodTruck.FoodTruckApi.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Http;

namespace Api.FoodTruck.FoodTruckApi.Controllers
{
    [RoutePrefix("FoodTruck/Location")]
    public class FoodTruckLocationController : ApiController
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
        [HttpGet]
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
                //exxxx
            }
            return new HttpActionResult(HttpStatusCode.OK, response);
        }
    }
}