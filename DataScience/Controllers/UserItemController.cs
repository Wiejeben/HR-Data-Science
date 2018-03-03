using System.Collections.Generic;
using System.Web.Mvc;
using DataScience.Models.UserItem;
using DataScience.Services;
using DataScience.Services.Similarity;

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
            var castedUserId = int.Parse(userId);
            var payload = GetPayload();
            var users = GetUsers(payload);

            if (!users.TryGetValue(castedUserId, out var user))
            {
                throw new KeyNotFoundException("User ID did not match to a user.");
            }

            users.Remove(castedUserId);
            
            ViewBag.UserId = castedUserId;
            ViewBag.Users = users;
            ViewBag.User = user;
            ViewBag.Articles = GetArticles(payload);
            
            return View();
        }

        private List<string[]> GetPayload()
        {
            return DataSetLoader.Load("userItem");
        }

        private SortedDictionary<int, User> GetUsers(List<string[]> payload)
        {
            return Models.UserItem.User.Populate(payload);
        }

        private SortedDictionary<int, Article> GetArticles(List<string[]> payload)
        {
            return Article.Populate(payload);
        }
    }
}