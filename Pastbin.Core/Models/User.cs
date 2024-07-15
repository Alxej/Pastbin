using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Pastbin.Core.Models
{
    public class User
    {
        public const int MAX_USERNAME_LENGTH = 32;
        public const int MAX_NAME_LENGTH = 256;
        public const int MAX_PASSWORD_LENGTH = 64;
        private User(Guid id, string userName,string password, string name, string lastName, string surname) 
        {
            Id = id;
            UserName = userName;
            Password = password;
            Name = name;
            LastName = lastName;
            Surname = surname;
        }

        public Guid Id { get; }
        public string UserName { get;} = string.Empty;
        public string Password { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Surname { get; } = string.Empty;

        public List<Post> Posts { get; } = new List<Post>();

        public static (User User, List<string> Errors) Create(Guid id, string userName, string password, string name, string lastName, string surname)
        {
            var errors = new List<string>();
            
            if (userName.Length > MAX_USERNAME_LENGTH || string.IsNullOrEmpty(userName))
                errors.Append("username length must be less than 33 symbols");

            if (password.Length > MAX_PASSWORD_LENGTH || string.IsNullOrEmpty(password))
                errors.Append("password length must be less than 65 symbols");

            if (name.Length > MAX_NAME_LENGTH || lastName.Length > MAX_NAME_LENGTH || surname.Length > MAX_NAME_LENGTH)
                errors.Append("full name parts lengths all must be less than 257 symbols");

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            var encryptedPassword = Convert.ToHexString(MD5.HashData(inputBytes));

            var user = new User(id, userName, encryptedPassword, name, lastName, surname);

            return (user, errors);
        }
    }
}
