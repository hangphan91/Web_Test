using Api.FoodTruck.Core.LocationApi.Models;
using Api.FoodTruck.FoodTruckApi.Utitlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace FoodTruck.Location.Api.Engine
{
    public class ValidateRequestEngine
    {
        public IHttpActionResult ActionResult { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidateRequestEngine(LocationRequest locationRequest)
        {
            var location = locationRequest.Location;
            if (locationRequest == null || locationRequest.Location == null)
            {
                Message = "Request must not be null";
                SetActionResult();
            }
            else if (location.StreetName.IsNull())
            {
                Message = "StreetName must not be null or empty.";
                SetActionResult();
            }
            else if (location.City.IsNull())
            {
                Message = "City must not be null or empty.";
                SetActionResult();
            }
            else if (location.State.IsNull())
            {
                Message = "State must not be null or empty.";
                SetActionResult();
            }
            else
            {
                IsValid = true;
            }
        }

        private void SetActionResult()
        {
            IsValid = false;
            ActionResult = new HttpActionResult(HttpStatusCode.BadRequest, new InsertLocationResponse(Message, IsValid));
        }
    }
}