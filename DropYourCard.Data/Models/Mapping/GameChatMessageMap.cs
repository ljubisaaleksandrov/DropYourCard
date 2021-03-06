using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class GameChatMessageMap : EntityTypeConfiguration<GameChatMessage>
    {
        public GameChatMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SenderUserName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GameChatMessage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.SenderUserName).HasColumnName("SenderUserName");
        }
    }
}
