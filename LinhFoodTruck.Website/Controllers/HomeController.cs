using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinhFoodTruck.Website.Models;
using System.Net.Http;
using Api.FoodTruck.DataManagement.DotNetCore.Location.Definition.Entities;
using Api.FoodTruck.FoodTruckApi.Models;

namespace LinhFoodTruck.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // call LinhFoodTruck.Location.API
            //var location = GetCurrentLocation();
            //ViewData["Message"] = "Your application description page.";
            //return View(location);
            return View();
        }

        public IActionResult About()
        {
            // call LinhFoodTruck.Location.API
            var location = GetCurrentLocation();
            ViewData["Message"] = "Your application description page.";

            return View(location);
        }

        public GetLocationResponse GetCurrentLocation()
        {
            // call LinhFoodTruck.Location.API
            var task = Task.Factory.StartNew(() => GetProductAsync());
            task.Wait();
            var location = task.Result.Result;
            return location;
        }
        static async Task<GetLocationResponse> GetProductAsync()
        {
            var product = new GetLocationResponse();
            var path = "https://localhost:44386/FoodTruck/Location/get/currentLocation";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<GetLocationResponse>();
            }
            return product;
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
