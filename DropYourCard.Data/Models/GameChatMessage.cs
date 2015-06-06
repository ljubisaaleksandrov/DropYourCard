using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class GameChatMessage
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public int GameID { get; set; }
        public string Message { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
