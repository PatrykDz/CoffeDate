using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeDate.Model.Models;
using CoffeDate.Model;
using Ninject;
using System.Diagnostics;
using CoffeDate.Model.Services;



namespace CoffeDate.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        private IUserService userService;

        [Inject]
        public TestController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            IEnumerable<User> users = userService.GetAll();

            return View(users);
        }

    }
}
