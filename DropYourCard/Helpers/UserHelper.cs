using DropYourCard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropYourCard.Helpers
{
    public static class UserHelper
    {
        private static DataContext repository = new DataContext();

        public static int LoggedUser()
        {
            var username = HttpContext.Current.User.Identity.Name;

            if (username != null)
            {
                var userId = repository.Users.FirstOrDefault(u => u.UserName == username).Id;
                return userId;
            }

            return -1;
        }
    }
}