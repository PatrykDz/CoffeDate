using CoffeDate.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeDate.Model.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByID(int id);
        User GetByID(Guid key);
        void Save(User entity);
        void Delete(User entity);

    }
}
