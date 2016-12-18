using System.Web.Mvc;

namespace EQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin")) {
                ViewBag.Role = "Admin";
                return View("~/Views/Tickets/AdminView.cshtml");
            } else if (User.IsInRole("User")) {
                ViewBag.Role = "User";
                return View("~/Views/Tickets/Create.cshtml");
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