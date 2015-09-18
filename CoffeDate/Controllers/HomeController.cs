using CoffeDate.Model.Models;
using CoffeDate.Repository.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeDate.Controllers
{
    public partial class HomeController : Controller
    {

        private IUserService userService;


        [Inject]
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }


        public virtual ActionResult Index()
        {
            ViewBag.Head = "Znajdź idealnego partnera!";
            ViewBag.Message = "Poznaj osoby, z którymi napijesz się ulubionej kawy...";

            return View();
        }

        public virtual ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {

            //            if (ModelState.IsValid)
            //          {

            userService.Save(u);
            ViewBag.Message = "Zarejestrowano";

            Session["LoggedUserId"] = u.UserId.ToString();
            Session["LoggedUserFirstName"] = u.FirstName.ToString();
            return RedirectToAction("Match", "Match", new { Match = "" });

            //        }
            return View(Views.Index, u);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string EmailAddress, string Password)
        {
            User u = userService.GetByEmailPassword(EmailAddress, Password);

            if (u != null)
            {
                Session["LoggedUserId"] = u.UserId.ToString();
                Session["LoggedUserFirstName"] = u.FirstName.ToString();
                return RedirectToAction("Match", "Match", new { Match = "" });
            }
            else
            {
                return View(Views.Index);

            }

        }

        public ActionResult Logout()
        {
            Session["LoggedUserId"] = null;
            Session["LoggedUserFirstName"] = null;

            return RedirectToAction("Index", "Home", new { Message = "Błędny login lub hasło" });
        }


        public ActionResult TermsOfUse()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }

    }
}
