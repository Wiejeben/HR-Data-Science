using System.Collections.Generic;
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
            ViewBag.Message = "Ratings";
            ViewBag.Users = GetUsers(GetPayload());
            ViewBag.Articles = GetArticles(GetPayload());

            return View();
        }

        // GET
        public ActionResult View(string userId)
        {
            ViewBag.UserId = int.Parse(userId);
            ViewBag.Users = GetUsers(GetPayload());
            ViewBag.Articles = GetArticles(GetPayload());
            
            return View();
        }

        private List<string[]> GetPayload()
        {
            return DataSetLoader.Load("userItem");
        }

        private Dictionary<int, User> GetUsers(List<string[]> payload)
        {
            return Models.UserItem.User.Populate(payload);
        }

        private Dictionary<int, Article> GetArticles(List<string[]> payload)
        {
            return Article.Populate(payload);
        }
    }
}