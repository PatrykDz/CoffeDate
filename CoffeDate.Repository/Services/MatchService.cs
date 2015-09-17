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





            Dictionary<int, string> CoffeTypeDictionary = new Dictionary<int, string>();
            CoffeTypeDictionary.Add(1, "Sypana");
            CoffeTypeDictionary.Add(2, "Rozpuszczalna");
            CoffeTypeDictionary.Add(3, "Z ekspresu");
            CoffeTypeDictionary.Add(4, "Cappucino");
            CoffeTypeDictionary.Add(5, "Latte");










        }

        public IEnumerable<User> GetCandidates(int? id)
        {
            var result = Session.CreateCriteria(typeof(User))
                   .AddOrder(Order.Desc("CoffeType"))
                   .AddOrder(Order.Desc("Additive"))
                   .AddOrder(Order.Desc("Sugar"))
                   .List<User>();





            return result;
        }





        public override string ToString()
        {
            return base.ToString();
        }



    }
}