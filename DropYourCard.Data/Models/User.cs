using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class User
    {
        public User()
        {
            this.ExceptionLogs = new List<ExceptionLog1>();
            this.LoginSessions = new List<LoginSession>();
            this.Players = new List<Player>();
            this.UserInfoes = new List<UserInfo>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsSuspendedOnChat { get; set; }
        public bool IsVerified { get; set; }
        public int PlayStatus { get; set; }
        public Nullable<bool> Gender { get; set; }
        public virtual ICollection<ExceptionLog1> ExceptionLogs { get; set; }
        public virtual ICollection<LoginSession> LoginSessions { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<UserInfo> UserInfoes { get; set; }
    }
}
