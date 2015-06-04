using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public virtual User User { get; set; }
    }
}
