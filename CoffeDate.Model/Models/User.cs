using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeDate.Model.Models
{
    public class User : IUser
    {
        public virtual int UserId { get; set; }
        [Display(Name="First Name")]
        public virtual string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public virtual string EmailAddress { get; set; }
        [Display(Name="Val")]
        public virtual int Val { get; set;}
    }
}