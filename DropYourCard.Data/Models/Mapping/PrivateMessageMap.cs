using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class PrivateMessageMap : EntityTypeConfiguration<PrivateMessage>
    {
        public PrivateMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SenderUserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ReceiverUserName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PrivateMessage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.SenderUserName).HasColumnName("SenderUserName");
            this.Property(t => t.ReceiverUserName).HasColumnName("ReceiverUserName");
        }
    }
}
