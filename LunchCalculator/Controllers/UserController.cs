using LunchCalculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LunchCalculator.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User check = UserDatabaseInterface.readUser(username);
            if (!(check is null) && check.validPassword(password, username))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Restriction(string restriction)
        {
            User check = UserDatabaseInterface.readUser(HttpContext.Session.GetString("username"));
            if (!(check is null))
            {
                check.dietaryRestrictions.Remove(restriction);
                UserDatabaseInterface.updateUser(check);
            }
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult Requirement(string requirement)
        {
            User check = UserDatabaseInterface.readUser(HttpContext.Session.GetString("username"));
            if (!(check is null))
            {
                check.dietaryRequirements.Remove(requirement);
                UserDatabaseInterface.updateUser(check);
            }
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult CreateAccount(string username, string password, string passwordcon, string zip)
        {
            User check = UserDatabaseInterface.readUser(username);
            if ((check is null) && password.Equals(passwordcon))
            {
                UserDatabaseInterface.createUser(new Models.User { username = username, password = Models.User.hashPassword(password, username), zip = zip });
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Profile()
        {
            string username = HttpContext.Session.GetString("username");
            User user = UserDatabaseInterface.readUser(username);
            if (username is null || user is null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.profile = user;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Profile(string old, string password, string passwordcon, string restriction, string requirement, string zip)
        {
            string username = HttpContext.Session.GetString("username");
            User check = UserDatabaseInterface.readUser(username);
            if (!(check is null) && check.validPassword(old, username))
            {
                if (!(requirement is null) && !requirement.Trim().Equals(""))
                    check.dietaryRequirements.Add(requirement);
                if (!(restriction is null) && !restriction.Trim().Equals(""))
                    check.dietaryRestrictions.Add(restriction);
                if (!(zip is null) && !zip.Trim().Equals(""))
                    check.zip = zip;
                if (!(password is null) && !password.Equals("") && password.Equals(passwordcon))
                {
                    check.password = Models.User.hashPassword(password, username);
                }
                UserDatabaseInterface.updateUser(check);
                ViewBag.profile = check;
            }
            return View();
        }

    }
}
