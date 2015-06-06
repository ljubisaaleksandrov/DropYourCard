using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class ExceptionLog1Map : EntityTypeConfiguration<ExceptionLog1>
    {
        public ExceptionLog1Map()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Url)
                .HasMaxLength(50);

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ExceptionLogs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsSolved).HasColumnName("IsSolved");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.ExceptionLogs)
                .HasForeignKey(d => d.UserID);

        }
    }
}
