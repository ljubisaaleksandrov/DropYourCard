using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CardsInHand)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.CardsInDeck)
                .IsFixedLength()
                .HasMaxLength(120);

            // Table & Column Mappings
            this.ToTable("Player");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.CardsInHand).HasColumnName("CardsInHand");
            this.Property(t => t.CardsInDeck).HasColumnName("CardsInDeck");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.Dots).HasColumnName("Dots");
            this.Property(t => t.Win_Lose).HasColumnName("Win/Lose");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Players1)
                .HasForeignKey(d => d.GameID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Players)
                .HasForeignKey(d => d.UserID);

        }
    }
}
