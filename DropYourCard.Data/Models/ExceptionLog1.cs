using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class ExceptionLog1
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsSolved { get; set; }
        public virtual User User { get; set; }
    }
}
