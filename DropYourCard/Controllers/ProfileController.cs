using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropYourCard.Data.Models;
using DropYourCard.Models;

namespace DropYourCard.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private DataContext dataContext;

        public ProfileController()
        {
            dataContext = new DataContext();
        }

        //
        // GET: /Profile/

        public ActionResult Index(int id)
        {
            User user = dataContext.Users.FirstOrDefault(u => u.Id == id);
            UserInfo userInfo = dataContext.UserInfoes.FirstOrDefault(u => u.Id == id);
            
            if (userInfo != null && user != null)
            {
                UserDetails userDetails = new UserDetails()
                {
                    Address = userInfo.Address,
                    City = userInfo.City,
                    Country = userInfo.Country,
                    DOB = userInfo.DOB,
                    Email = user.Email,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Password = user.Password,
                    Phone = userInfo.Phone,
                    UserName = user.UserName
                };
                return View(userDetails);
            }
            return View((UserDetails)null);
        }



    }
}
