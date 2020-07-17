using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchCalculator.Models
{
    public class Location
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public List<string> display_address { get; set; }

    }

    public class Center
    {
        public double longitude { get; set; }
        public double latitude { get; set; }

    }

    public class Region
    {
        public Center center { get; set; }

    }
    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

    }

}
