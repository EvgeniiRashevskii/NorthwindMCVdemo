using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindMCVdemo.Models;

namespace NorthwindMCVdemo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Authorize(Logins LoginModel)
        {
            TilausDB3Entities4 db = new TilausDB3Entities4();

            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);
            if (LoggedUser != null)
            {
                ViewBag.LoginMessage = "Successfull login";
                ViewBag.LoggedStatus = "In";
                Session["UserName"] = LoggedUser.UserName;
               return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                //LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Login", LoginModel);
            }
        }



        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home"); 

        }
        public ActionResult Index()
        {
            ViewBag.LoggedStatus = "In";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yhtiön Perustietojen kuvailua";
            ViewBag.Herja = "Ole huolellinen, niin ei tule virhettä";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yhteystietojamme";
            ViewBag.Herja = Session["UserName"];
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }
    }
}