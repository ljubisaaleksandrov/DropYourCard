using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.AccessLevel).HasColumnName("AccessLevel");
            this.Property(t => t.IsSuspended).HasColumnName("IsSuspended");
            this.Property(t => t.IsSuspendedOnChat).HasColumnName("IsSuspendedOnChat");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
            this.Property(t => t.PlayStatus).HasColumnName("PlayStatus");
            this.Property(t => t.Gender).HasColumnName("Gender");
        }
    }
}
