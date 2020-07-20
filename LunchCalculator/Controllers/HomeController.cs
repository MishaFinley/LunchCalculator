using LunchCalculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LunchCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User user = UserDatabaseInterface.readUser(HttpContext.Session.GetString("username"));
            if (!(user is null))
            {
                ViewBag.profile = user;
            }
            ViewBag.resturants = new Resturant[0];
            return View();
        }
        [HttpPost]
        public IActionResult Index(string zip, string searchtext)
        {
            User user = UserDatabaseInterface.readUser(HttpContext.Session.GetString("username"));
            if (!(user is null))
            {
                ViewBag.profile = user;
            }
            //TODO find resturants from zip and restrictions
            //TODO setup response for resurants in ViewBag
            ViewBag.resturants = new Resturant[0];
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
