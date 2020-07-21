using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchCalculator.Models
{
    [Serializable]
    public class ResturauntDetails : Resturant
    {

        public bool is_claimed { get; set; }
        public List<string> photos { get; set; }
        public List<Hour> hours { get; set; }
        public List<SpecialHour> special_hours { get; set; }
    }
    [Serializable]
    public class Open
    {
        public bool is_overnight { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int day { get; set; }

    }
    [Serializable]
    public class Hour
    {
        public List<Open> open { get; set; }
        public string hours_type { get; set; }
        public bool is_open_now { get; set; }

    }
    [Serializable]
    public class SpecialHour
    {
        public string date { get; set; }
        public object is_closed { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool is_overnight { get; set; }

    }
}


