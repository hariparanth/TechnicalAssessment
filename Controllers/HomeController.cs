using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TECHNICAL_ASSESSMENT.Models.Entity;

namespace TECHNICAL_ASSESSMENT.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RedirectLogin()
        {
            return View("Login");
        }
        public void Old()
        {

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}