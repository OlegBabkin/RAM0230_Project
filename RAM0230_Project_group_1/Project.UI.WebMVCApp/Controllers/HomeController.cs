using System.Web.Mvc;
using Project.UI.WebMVCApp.Models;
using Project.Domain.Core;

namespace Project.UI.WebMVCApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application home page.";

            return View();
        }
        [Authorize(Roles = "teacher")]
        public ActionResult About()
        {
            ViewBag.Message = User.Identity.GetUserRole();

            return View();
        }

        public ActionResult Contact()
        {
            int id = User.Identity.GetUserId<int>();
            ViewBag.Message = "id: " + id.ToString();

            return View();
        }
    }
}