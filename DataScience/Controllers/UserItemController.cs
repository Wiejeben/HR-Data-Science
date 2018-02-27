using System.Web.Mvc;
using DataScience.Models.UserItem;
using DataScience.Services;

namespace DataScience.Controllers
{
    public class UserItemController : Controller
    {
        // GET
        public ActionResult Index()
        {
            ViewBag.Message = "Users from the userItem dataset";
            ViewBag.Users = GetUsers();

            return View();
        }

        // GET
        public ActionResult View(string userId)
        {
            ViewBag.UserId = userId;
            ViewBag.Users = GetUsers();
            return View();
        }

        private UserItems GetUsers()
        {
            var dataset = DataSetLoader.Load("userItem");
            return new UserItems(dataset);
        }
    }
}