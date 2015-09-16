using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeDate.Model.Models;
using NHibernate;

namespace CoffeDate.Model.Services
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
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}