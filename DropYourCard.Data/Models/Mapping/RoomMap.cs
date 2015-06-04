using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.GameCodeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PlayingList)
                .IsFixedLength()
                .HasMaxLength(200);

            this.Property(t => t.WaitingList)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Room");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.GameCodeName).HasColumnName("GameCodeName");
            this.Property(t => t.PlayingList).HasColumnName("PlayingList");
            this.Property(t => t.WaitingList).HasColumnName("WaitingList");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Rooms)
                .HasForeignKey(d => d.GameID);

        }
    }
}
