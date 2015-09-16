using CoffeDate.Model;
using CoffeDate.Model.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeDate.Repository.Services
{
    public class MatchService : IMatchService
    {
        protected readonly ISession Session;
        private IRepository<User> userRepository;


        public MatchService(ISession session, IRepository<User> repository)
        {
            this.Session = session;
            this.userRepository = repository;
        }

        public IEnumerable<User> GetCandidates(int? id)
        {
            var result = Session.CreateCriteria(typeof(User))
                   .AddOrder(Order.Desc("Val"))
                   //.AddOrder(Order.Desc("LastName"))
                   .List<User>();

            return result;
        }

    }
}