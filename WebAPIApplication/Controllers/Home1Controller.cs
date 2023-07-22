using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class Home1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult Basket()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult TempPractice()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult FrontDesign()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Company()
        {
            return View();
        }

        public ActionResult PagingPract()
        {
            return View();
        }
     

       
    }
}
