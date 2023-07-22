using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
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
        public ActionResult jqPracticeui()
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
        [Authorize(Roles = "Admin,Company,Customer")]
        public ActionResult Company()
        {
            return View();
        }
        public ActionResult GoodsType()
        {
            return View();
        }
        public ActionResult BidByCriteria()
        {
            return View();
        }
        public ActionResult PagingPract()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Company")]
        public ActionResult AdminCompany()
        {
            return View();
        }

        public ActionResult ValidateAuth()
        {
            return View();
        }

        public ActionResult FormBuild()
        {
            return View();
        }

        public ActionResult SoldItemForCustomer()
        {
            return View();
        }
        public ActionResult AppliedBidForCompany()
        {
            return View();
        }

        public ActionResult UseCompany()
        {
            return View();
        }
        public ActionResult GetBidByProduct()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Customer")]
        public ActionResult CriteriaForApplyBid()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Customer")]
        public ActionResult Bid()
        {
            return View();
        }


        [Authorize(Roles = "Admin,Company,Customer")]
        public ActionResult DeshboardForCompany()
        {
            return View();
        }


    }
}

