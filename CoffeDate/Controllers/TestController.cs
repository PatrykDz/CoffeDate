using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeDate.Model.Models;
using CoffeDate.Model;
using Ninject;
using System.Diagnostics;
using CoffeDate.Repository.Services;



namespace CoffeDate.Controllers
{
    public partial class MatchController : Controller
    {
        //
        // GET: /Test/

        private IUserService userService;
        private IMatchService matchService;

        [Inject]
        public MatchController(IUserService userService, IMatchService matchService)
        {
            this.userService = userService;
            this.matchService = matchService;
        }

        public virtual ActionResult Index()
        {
            IEnumerable<User> users = userService.GetAll();
            return View(users);
        }

        public virtual ActionResult Edit(int? id)
        {
            User userEntity = new User();
            if(id.HasValue && id != 0)
            {
                  userEntity = userService.GetByID((int)id);
            }
            return View(userEntity);
        }


        public virtual ActionResult Match(int? id)
        {
            IEnumerable<User> matches = matchService.GetCandidates(1);

            return View(matches);
        }

    }
}
