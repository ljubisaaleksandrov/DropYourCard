using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class Game
    {
        public Game()
        {
            this.Players1 = new List<Player>();
            this.Rooms = new List<Room>();
        }

        public int Id { get; set; }
        public string CodeName { get; set; }
        public int NOPlayers { get; set; }
        public string Players { get; set; }
        public Nullable<int> ActiverPlayer { get; set; }
        public string CardsOnTable { get; set; }
        public string CardsInDeck { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Player> Players1 { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
