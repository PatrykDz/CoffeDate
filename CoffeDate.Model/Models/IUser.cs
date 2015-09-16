using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeDate.Model.Models
{
    public interface IUser
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        int Val { get; set;}
        

    }
}
