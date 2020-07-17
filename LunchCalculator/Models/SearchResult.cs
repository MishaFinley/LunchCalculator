using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchCalculator.Models
{
    public class SearchResult
    {
        public List<Resturant> businesses { get; set; }
        public int total { get; set; }
        public Region region { get; set; }

    }
}
