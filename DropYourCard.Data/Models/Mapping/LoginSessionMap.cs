using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class LoginSessionMap : EntityTypeConfiguration<LoginSession>
    {
        public LoginSessionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LoginSession");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.LastLogin).HasColumnName("LastLogin");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.LoginSessions)
                .HasForeignKey(d => d.UserID);

        }
    }
}
