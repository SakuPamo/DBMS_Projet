using DBMSProjet.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMSProjet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Globle.userManegement == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            if (Globle.userManegement.UserCategory == "Admin")
            {
                return View("DasboardAdmin");
            }
            else if (Globle.userManegement.UserCategory == "Consultant")
            {
                return View("DashboardConsultant");
            }
            else if(Globle.userManegement.UserCategory == "Customer")
            {
                return View("DashboardCustomer");
            }
            else
            {
                return View("DasboardAdmin");
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