using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string SenderUserName { get; set; }
    }
}
