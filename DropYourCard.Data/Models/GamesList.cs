using System;
using System.Collections.Generic;

namespace DropYourCard.Data.Models
{
    public partial class GamesList
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
    }
}
