using LunchCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;

namespace LunchCalculator.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult SearchFood()
        {
            RestClient client = new RestClient("https://api.yelp.com/v3businesses/search?term=delis");
            RestRequest request = new RestRequest(Method.POST); ;
            request.AddHeader("Authorization", "Bearer v1AI_S2LzYgDRy37YwJL1idcwfOCHr9DDGv58kvOUUEIxdJDU-QInbxpBzmXtYiihq5ZZa3tlWhOQzMHRjrRd-pZzw32ChpU44ZoEEdyP_ty6PYlJOQsUZ2MjWYQX3Yx");
            request.AddParameter("location", "SaltLakeCity");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                SearchResult json = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return View(json);
            }
            else
            {
                Console.WriteLine("ERROR", (int)response.StatusCode, response.ErrorMessage);
            }
            return View();
        }
        public IActionResult ResturantDetails(string id)
        {
            ViewBag.resturant = new Resturant();
            //get resturant by id from yelp
            return View();
        }
    }
}
