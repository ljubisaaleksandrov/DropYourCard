using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class LoginSession
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string IPAddress { get; set; }
        public System.DateTime LastLogin { get; set; }
        public virtual User User { get; set; }
    }
}
