using DBMSProjet.Database;
using DBMSProjet.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMSProjet.Controllers
{
    public class LoginController : Controller
    {
        private MACBuildersEntities mACBuildersEntities = new MACBuildersEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(model); // get return if the user is valid

                if (isValidUser != null)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            return View(model);
        }

        public UserManagement IsValidUser(LoginViewModel model)
        {
            using (var dataContext = new MACBuildersEntities())
            {
                //Retireving the user details from DB based on username and password enetered by user.
                UserManagement user = dataContext.UserManagements.Where(query => query.LoginName.Equals(model.UserName) && query.Password.Equals(model.Password)).SingleOrDefault();
                //If user is present, then true is returned.
                if (user == null)
                {
                    Globle.IsLog = false;
                    return null;
                }
                //If user is not present false is returned.
                else
                {
                    Globle.IsLog = true;
                    Globle.userManegement = user;
                    return user;
                }


            }
        }

        public ActionResult Logout()
        {
            Globle.IsCutomer = false;
            Globle.IsLog = false;
            Globle.userManegement = null;
            return RedirectToAction("Index");
        }
    }
}