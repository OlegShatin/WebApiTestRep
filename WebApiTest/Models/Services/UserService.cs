using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Models.Services
{
    public class UserService
    {
        public static string Hash(string input)
        {
            return string.Join("", (new System.Security.Cryptography.SHA1Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(input))).Select(x => x.ToString("x2")).ToArray());
        }
        public User GetUserByCredentials(string email, string password)
        {
            if (email != "email@domain.com" || !Hash(password).Equals(Hash("password")))
            {
                return null;
            }
            User user = new User() { Id = 1, Email = "email@domain.com", PasswordHash = Hash("password"), Name = "Ole Petter Dahlmann" };
            
            return user;
        }
    }
}