using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        public string CardsInHand { get; set; }
        public string CardsInDeck { get; set; }
        public int Points { get; set; }
        public Nullable<int> Dots { get; set; }
        public Nullable<bool> Win_Lose { get; set; }
        public int Status { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
