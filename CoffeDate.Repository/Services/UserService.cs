using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeDate.Model.Models;
using NHibernate;
using NHibernate.Criterion;

namespace CoffeDate.Repository.Services
{
    public class UserService : IUserService
    {

        protected readonly ISession Session;

        private IRepository<User> userRepository;


        public UserService(IRepository<User> userRepository, ISession session)
        {
            this.userRepository = userRepository;
            this.Session = session;
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetByID(int id)
        {
            return Session.Get<User>(id);
        }

        public User GetByID(Guid key)
        {
            return Session.Get<User>(key);
        }

        public void Save(User entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        public void Delete(User entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

    }
}