using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin")) {
                ViewBag.Role = "Admin";
                return View("~/Views/Tickets/AdminView");
            } else if (User.IsInRole("User")) {
                ViewBag.Role = "User";
                return View("~/Views/Tickets/Create");
            } else {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}