using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Iesi.Collections;


namespace CoffeDate.Model.Models
{
    public class User : IUser
    {
        public virtual int UserId { get; set; }
      
        [Required(ErrorMessage = "Podaj imię", AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "Imię nie może mieć więcej niż 30 znaków.")]
        [Display(Name="Imię")]
        public virtual string FirstName { get; set; }
       
        [Required(ErrorMessage = "Podaj nazwisko", AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "Nazwisko nie może mieć więcej niż 30 znaków.")]
        [Display(Name = "Nazwisko")]
        public virtual string LastName { get; set; }
        

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage="Podaj adres e-mail", AllowEmptyStrings=false)]
        [StringLength(30, ErrorMessage = "E-mail nie może mieć więcej niż 50 znaków.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage="Podaj prawidłowy adres e-mail")]
        public virtual string EmailAddress { get; set; }
        
        [Display(Name="Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Podaj hasło", AllowEmptyStrings=false)]
        [StringLength(20, MinimumLength=3, ErrorMessage="Hasło musi mieć od 3 do 20 znaków")]
        public virtual string Password { get; set;}
        
        [Display(Name = "Typ Kawy")]
        [Range(1, 5, ErrorMessage="Wybierz odpowiedni typ kawy")]
        public virtual int CoffeType { get; set;}

        [Display(Name = "Ilość cukru")]
        [Range(0, 5, ErrorMessage = "Wybierz odpowiednią ilość cukru")]
        public virtual int Sugar { get; set;}

        [Display(Name = "Dodatki")]
        [Range(1, 3, ErrorMessage = "Wybierz odpowiedni dodatek")]
        public virtual int Additive { get; set;}


        public virtual string CoffeTypeStr { get; set; }
        public virtual string AdditiveStr { get; set; }
        public virtual bool LoggedIn { get; set;}

    }
}