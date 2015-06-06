using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class ExceptionLogMap : EntityTypeConfiguration<ExceptionLog>
    {
        public ExceptionLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Type, t.Message, t.DateCreated });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ExceptionLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
        }
    }
}
