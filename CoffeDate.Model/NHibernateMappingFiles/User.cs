using System.Collections.Generic;
using System.Text;
using System;
using NHibernate.Collection;
using NHibernate.Mapping;
using Iesi.Collections;
namespace CoffeDate.Model.NHibernateMappingFiles
{
    public abstract partial class User
    {
     /*   public virtual int UserId { get; set; }
        
        public virtual string FirstName { get; set; }
        
        public virtual string LastName { get; set; }

        public virtual string EmailAddress { get; set; }
      */
    }

    public partial class UserImpl : User
    {

    }
}