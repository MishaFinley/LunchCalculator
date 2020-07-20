using Nancy.Json;
using System;
using System.Collections.Generic;

namespace LunchCalculator.Models
{
    [Serializable]
    public class Resturant
    {
        public string id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public bool is_closed { get; set; }
        public string url { get; set; }
        public int review_count { get; set; }
        public List<Category> categories { get; set; }
        public double rating { get; set; }
        public Coordinates coordinates { get; set; }
        public List<string> transactions { get; set; }
        public string price { get; set; }
        public Location location { get; set; }
        public string phone { get; set; }
        public string display_phone { get; set; }
        public double distance { get; set; }
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
        public static Resturant FromString(string json)
        {
            return new JavaScriptSerializer().Deserialize<Resturant>(json);
        }
    }
    [Serializable]
    public class Category
    {
        public string alias { get; set; }
        public string title { get; set; }

    }
}
