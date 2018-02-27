using System.Web.Mvc;

namespace DataScience.Controllers
{
    public class UserItemController : Controller
    {
        // GET
        public ActionResult Index()
        {
            ViewBag.Message = "Your application User Item page.";

            return View();
        }
    }
}