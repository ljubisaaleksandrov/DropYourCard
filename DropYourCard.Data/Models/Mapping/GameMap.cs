using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CodeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Players)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CardsOnTable)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.CardsInDeck)
                .IsFixedLength()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Game");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CodeName).HasColumnName("CodeName");
            this.Property(t => t.NOPlayers).HasColumnName("NOPlayers");
            this.Property(t => t.Players).HasColumnName("Players");
            this.Property(t => t.ActiverPlayer).HasColumnName("ActiverPlayer");
            this.Property(t => t.CardsOnTable).HasColumnName("CardsOnTable");
            this.Property(t => t.CardsInDeck).HasColumnName("CardsInDeck");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
