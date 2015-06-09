using DropYourCard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropYourCard.Helpers
{
    public static class UserHelper
    {
        private static readonly DataContext dataContext = new DataContext();

        public static int LoggedUserId()
        {
            var currentUser = LoggedUser();
            return LoggedUser() != null ? currentUser.Id : -1;
        }

        public static string LoggedUserUserName()
        {
            var currentUser = LoggedUser();
            return LoggedUser() != null ? currentUser.UserName : "";
        }

        public static User LoggedUser()
        {
            var username = HttpContext.Current.User.Identity.Name;
            return username != null ? dataContext.Users.FirstOrDefault(u => u.UserName == username) : (User) null;
        }

        public static UserInfo LoggedUserInfo()
        {
            User currentUser = LoggedUser();
            UserInfo userInfo = dataContext.UserInfoes.FirstOrDefault(u => u.UserID == currentUser.Id);
            return userInfo != (UserInfo)null ? userInfo : (UserInfo)null;
        }
    }
}