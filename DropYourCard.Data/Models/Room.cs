using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public int GameID { get; set; }
        public string GameCodeName { get; set; }
        public string PlayingList { get; set; }
        public string WaitingList { get; set; }
        public virtual Game Game { get; set; }
    }
}
