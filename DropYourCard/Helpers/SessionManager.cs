using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropYourCard.Data.Models;

namespace DropYourCard.Helpers
{
    public class SessionManager
    {
        public string ReturnUrl { get; set; }
        public User CurrentUser { get; set; }
    }
}