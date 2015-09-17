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


        private Dictionary<int, string> CoffeTypeDictionary;
        private Dictionary<int, string> AdditiveDictionary; 

        public MatchService(ISession session, IRepository<User> repository)
        {
            this.Session = session;
            this.userRepository = repository;





            CoffeTypeDictionary = new Dictionary<int, string>();
            CoffeTypeDictionary.Add(1, "Sypana");
            CoffeTypeDictionary.Add(2, "Rozpuszczalna");
            CoffeTypeDictionary.Add(3, "Z ekspresu");
            CoffeTypeDictionary.Add(4, "Cappucino");
            CoffeTypeDictionary.Add(5, "Latte");

            AdditiveDictionary = new Dictionary<int, string>();
            AdditiveDictionary.Add(1, "Czarna");
            AdditiveDictionary.Add(2, "Śmietanka");
            AdditiveDictionary.Add(3, "Mleko");


        }

        public IEnumerable<User> GetCandidates(int? id)
        {
            var result = Session.CreateCriteria(typeof(User))
                   .AddOrder(Order.Desc("CoffeType"))
                   .AddOrder(Order.Desc("Additive"))
                   .AddOrder(Order.Desc("Sugar"))
                   .List<User>();



            foreach (User u in result)
            {
                u.CoffeTypeStr = CoffeTypeDictionary[u.CoffeType];
                u.AdditiveStr = AdditiveDictionary[u.Additive];
                //if (u.UserId == Session["LoggedUserId"]) u.LoggedIn = true;
            }






            return result;
        }





        public override string ToString()
        {

            
            return base.ToString();
        }



    }
}