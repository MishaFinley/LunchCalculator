﻿using LunchCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LunchCalculator.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult SearchFood()
        {
            RestClient client = new RestClient("https://api.yelp.com/v3/businesses/search?");
            RestRequest request = new RestRequest(Method.GET); ;
            request.AddHeader("Authorization", "Bearer v1AI_S2LzYgDRy37YwJL1idcwfOCHr9DDGv58kvOUUEIxdJDU-QInbxpBzmXtYiihq5ZZa3tlWhOQzMHRjrRd-pZzw32ChpU44ZoEEdyP_ty6PYlJOQsUZ2MjWYQX3Yx");
            request.AddParameter("term","resturant");
            request.AddParameter("location", "84116");
            IRestResponse response = client.Execute(request);
            SearchResult result;
            if (response.IsSuccessful)
            {
                string json = response.Content;
                result = SearchResult.FromJSON(response.Content);
            }
            else
            {
                result = new SearchResult { businesses = new List<Resturant>() };
                result.businesses.Add(new Resturant { name = "response failure" });
                Console.WriteLine("ERROR", (int)response.StatusCode, response.ErrorMessage);
            }
            ViewBag.result = result;
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
