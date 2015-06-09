using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DropYourCard.Data.Models;
using DropYourCard.Helpers;
using DropYourCard.Models;
using System.Text.RegularExpressions;
using System.Web.Routing;
using DropYourCard.Enums;

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

        [HttpGet]
        public ActionResult Index(string username)
        {
            User user = dataContext.Users.FirstOrDefault(u => u.UserName == username);
            UserInfo userInfo = dataContext.UserInfoes.FirstOrDefault(u => u.UserID == user.Id);
            
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

        [HttpGet]
        public ActionResult Edit(string username)
        {
            dataContext = new DataContext();
            User user = dataContext.Users.FirstOrDefault(u => u.UserName == username);
            UserInfo userInfo = dataContext.UserInfoes.FirstOrDefault(u => u.UserID == user.Id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDetails model)
        {
            if (ModelState.IsValid)
            {
                dataContext = new DataContext();
                User user = dataContext.Users.FirstOrDefault(u => u.UserName == model.UserName);
                UserInfo userInfo = dataContext.UserInfoes.FirstOrDefault(u => u.UserID == user.Id);
                try
                {
                    user.Password = model.Password;
                    userInfo.FirstName = model.FirstName;
                    userInfo.LastName = model.LastName;
                    userInfo.DOB = model.DOB;
                    userInfo.Phone = model.Phone;
                    userInfo.Address = model.Address;
                    userInfo.City = model.City;
                    userInfo.Country = model.Country;

                    dataContext.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Messages()
        {
            var currentUser = UserHelper.LoggedUser();
            List<string> chattersList = GetChattersUserNames();

            string lastChatter = Request["userName"] ?? chattersList.FirstOrDefault();

            List<PrivateMessage> messages = dataContext.PrivateMessages.Where(m =>
                (m.SenderUserName == currentUser.UserName && m.ReceiverUserName == lastChatter) ||
                (m.SenderUserName == lastChatter && m.ReceiverUserName == currentUser.UserName)).ToList();
            ViewBag.currentUser = currentUser.UserName;
            ViewBag.chattersList = chattersList;
            ViewBag.listItems = GetAllUsersNames();
            SessionHelper.Store("receiver", lastChatter);
            
            return View(messages);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public PartialViewResult Messages(string userName)
        {
            var currentUser = UserHelper.LoggedUser();

            List<PrivateMessage> messages = dataContext.PrivateMessages.Where(m =>
                (m.SenderUserName == currentUser.UserName && m.ReceiverUserName == userName) ||
                (m.SenderUserName == userName && m.ReceiverUserName == currentUser.UserName)).ToList();

            //ViewBag.currentUser = currentUser.UserName;
            //ViewBag.chattersList = GetChattersUserNames();
            //ViewBag.listItems = GetAllUsersNames();

            SessionHelper.Store("receiver", userName);

            return PartialView("_GetMessages", messages);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public PartialViewResult NewMessage(string message)
        {
            message = message.Replace(System.Environment.NewLine, "<br />");
            string result = Regex.Replace(message, @"\r\n?|\n", "<br />");
            var currentUser = UserHelper.LoggedUser();
            object obj = SessionHelper.Retrieve("receiver");
            string userName = obj as string;
            dataContext.PrivateMessages.Add(new PrivateMessage()
            {
                DateCreated = DateTime.Now,
                Message = result,
                ReceiverUserName = userName,
                SenderUserName = currentUser.UserName
            });

            dataContext.SaveChanges();

            List<PrivateMessage> messages = dataContext.PrivateMessages.Where(m =>
                (m.SenderUserName == currentUser.UserName && m.ReceiverUserName == userName) ||
                (m.SenderUserName == userName && m.ReceiverUserName == currentUser.UserName)).ToList();

            //ViewBag.currentUser = currentUser.UserName;
            //ViewBag.chattersList = GetChattersUserNames();
            //ViewBag.listItems = GetAllUsersNames();

            return PartialView("_GetMessages", messages);
        }

        public PartialViewResult _GetChatters()
        {
            return PartialView(GetChattersUserNames());
        }


        /// <summary>
        /// Used to get all Users (UserNames) that interchanged messages with current user
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private List<string> GetChattersUserNames()
        {
            var currentUser = UserHelper.LoggedUser();
            IEnumerable<PrivateMessage> messages = dataContext.PrivateMessages.Where(m => m.SenderUserName == currentUser.UserName || m.ReceiverUserName == currentUser.UserName).ToList();
            IEnumerable<string> senders = messages.GroupBy(m => m.SenderUserName).Select(grp => grp.First().SenderUserName);
            IEnumerable<string> receivers = messages.GroupBy(m => m.ReceiverUserName).Select(grp => grp.First().ReceiverUserName);
            
            var result = senders.Union<string>(receivers, new StringComparer()).ToList();
            result.Remove(UserHelper.LoggedUserUserName());
            
            return result;
        }


        [NonAction]
        private IEnumerable<SelectListItem> GetAllUsersNames()
        {
            List<User> users = dataContext.Users.ToList();
            string currentUser = UserHelper.LoggedUserUserName();
            IEnumerable<SelectListItem> listItems =
                from u in users
                where u.UserName != currentUser
                select new SelectListItem()
                {
                    Selected = false,
                    Text = u.UserName,
                    Value = u.UserName
                };
            return listItems;
        }

        
    }

    class StringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y);
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

}
