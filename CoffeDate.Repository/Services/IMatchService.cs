using CoffeDate.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeDate.Repository.Services
{
    public interface IMatchService
    {
        IEnumerable<User> GetCandidates(int? id);
    }
}
