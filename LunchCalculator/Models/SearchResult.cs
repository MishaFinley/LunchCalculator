using Nancy.Json;
using System;
using System.Collections.Generic;

namespace LunchCalculator.Models
{
    [Serializable]
    public class SearchResult
    {
        public List<Resturant> businesses { get; set; }
        public int total { get; set; }
        public Region region { get; set; }
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
        public static SearchResult FromJSON(string json)
        {
            return new JavaScriptSerializer().Deserialize<SearchResult>(json);
        }

    }
}
