using LunchCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

namespace LunchCalculator.Controllers
{
    public class FoodController : Controller
    {
        //public IActionResult SearchFood()
        //{
        //    RestClient client = new RestClient("https://api.yelp.com/v3/businesses/search?");
        //    RestRequest request = new RestRequest(Method.GET); ;
        //    request.AddHeader("Authorization", "Bearer v1AI_S2LzYgDRy37YwJL1idcwfOCHr9DDGv58kvOUUEIxdJDU-QInbxpBzmXtYiihq5ZZa3tlWhOQzMHRjrRd-pZzw32ChpU44ZoEEdyP_ty6PYlJOQsUZ2MjWYQX3Yx");
        //    request.AddParameter("term", "resturant");
        //    request.AddParameter("location", "84116");
        //    IRestResponse response = client.Execute(request);
        //    SearchResult result;
        //    if (response.IsSuccessful)
        //    {
        //        string json = response.Content;
        //        result = SearchResult.FromJSON(response.Content);
        //    }
        //    else
        //    {
        //        result = new SearchResult { businesses = new List<Resturant>() };
        //        result.businesses.Add(new Resturant { name = "response failure" });
        //        Console.WriteLine("ERROR", (int)response.StatusCode, response.ErrorMessage);
        //    }
        //    ViewBag.result = result;
        //    return View();
        //}
        public static List<Resturant> SearchFood(string zip, string searchtext, string[] restrictions, string[] requirements)
        {
            RestClient client = new RestClient("https://api.yelp.com/v3/businesses/search?");
            RestRequest request = new RestRequest(Method.GET); ;
            request.AddHeader("Authorization", "Bearer v1AI_S2LzYgDRy37YwJL1idcwfOCHr9DDGv58kvOUUEIxdJDU-QInbxpBzmXtYiihq5ZZa3tlWhOQzMHRjrRd-pZzw32ChpU44ZoEEdyP_ty6PYlJOQsUZ2MjWYQX3Yx");
            if(searchtext == null || searchtext.Trim() == "")
            {
                request.AddParameter("term", "resturant");
            }
            else
            {
                
                request.AddParameter("term", "resturant,"+searchtext);
            }
            request.AddParameter("location", zip);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string json = response.Content;
                var result = SearchResult.FromJSON(response.Content);
                return result.businesses;
            }
            return new List<Resturant>();
        }
        public IActionResult ResturantDetails(string id)
        {
            RestClient client = new RestClient($"https://api.yelp.com/v3/businesses/{id}");
            RestRequest request = new RestRequest(Method.GET); ;
            request.AddHeader("Authorization", "Bearer v1AI_S2LzYgDRy37YwJL1idcwfOCHr9DDGv58kvOUUEIxdJDU-QInbxpBzmXtYiihq5ZZa3tlWhOQzMHRjrRd-pZzw32ChpU44ZoEEdyP_ty6PYlJOQsUZ2MjWYQX3Yx");
            //request.AddParameter("term", "resturant");
            //request.AddParameter("location", "84116");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string json = response.Content;
                var result = Resturant.FromString(response.Content);
                ViewBag.resturant = result;
            }
            return View();
        }
    }
}
