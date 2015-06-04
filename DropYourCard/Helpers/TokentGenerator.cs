using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DropYourCard.Data.Models;

namespace DropYourCard.Helpers
{
    public static class TokentGenerator
    {
        public static string GenerateToken(User user)
        {
            string token = "";
            byte[] username = Encoding.ASCII.GetBytes(user.UserName);
            byte[] password = Encoding.ASCII.GetBytes(user.Password);

            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                string usernameToken = Convert.ToBase64String(sha.ComputeHash(username)).Replace('&', '%');
                string passwordToken = Convert.ToBase64String(sha.ComputeHash(password)).Replace('&', '%');
                token = usernameToken.Substring(0, 10) + passwordToken.Substring(0, 10);
            }

            return token;
        }
    }
}