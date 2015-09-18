using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeDate.Model.Models;
using NHibernate;
using NHibernate.Criterion;
using System.Security.Cryptography;
using System.Text;

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





        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public void Save(User entity)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                entity.Password = GetMd5Hash(md5Hash,entity.Password);
            }

            Session.Save(entity);
            Session.Flush();
        }

        public void Delete(User entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }


        public User GetByEmailPassword(string email, string password)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                password = GetMd5Hash(md5Hash, password);
            }

            User user = Session.CreateCriteria(typeof(User))
             .Add(Expression.Eq("EmailAddress", email))
             .Add(Expression.Eq("Password", password))
             .UniqueResult<User>();


            return user;

        }



    }
}