using System.Web.Mvc;

namespace StackOverflowSurvey.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}