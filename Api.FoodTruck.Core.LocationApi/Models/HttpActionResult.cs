using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Api.FoodTruck.Core.LocationApi.Models
{
    public class HttpActionResult : IHttpActionResult
    {
        private readonly object _locationResponse;
        private readonly HttpStatusCode _statusCode;
        public HttpActionResult(HttpStatusCode statusCode, object response)
        {
            _statusCode = statusCode;
            _locationResponse = response;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(_locationResponse, new JsonSerializerSettings { Formatting = Formatting.None });
            return Task.FromResult(new HttpResponseMessage(_statusCode) { Content = new StringContent(json, Encoding.UTF8, "application/json") });
        }
    }
}