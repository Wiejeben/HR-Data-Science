using System.Web.Mvc;
using System.Collections.Generic;
using DataScience.Services.Simularity;

namespace DataScience.Controllers
{
    public class UserItemController : Controller
    {
        public ActionResult Index()
        {
            double[] x = { 4.75, 4.5, 5, 4.25, 4 };
            double[] y = { 4, 3, 5, 2, 1 };
//            double[] x = {5, 1, 3};
//            double[] y = {2, 4, 3};
            
            ViewBag.DataSets = new Dictionary<string, double[]>
            {
                {"x", x},
                {"y", y}
            };

            var list = SimularityList.Create(x, y);
            ViewBag.Euclidean = new Euclidean(list).Calculate();
            ViewBag.Manhattan = new Manhattan(list).Calculate();
            ViewBag.Pearson = new Pearson(list).Calculate();
            ViewBag.Cosine = new Cosine(list).Calculate();
            
            return View();
        }
    }
}