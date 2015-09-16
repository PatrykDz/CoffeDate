using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeDate.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T GetByID(Guid key);
        void Save(T entity);
        void Delete(T entity);
    }

    

}


