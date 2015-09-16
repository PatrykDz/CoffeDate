using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Web;

namespace CoffeDate.Model
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }

        public IEnumerable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetByID(int id)
        {
            return Session.Get<T>(id);
        }

        public T GetByID(Guid key)
        {
            return Session.Get<T>(key);
        }

        public void Save(T entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }
    }

}