using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DropYourCard.Data.Models.Mapping
{
    public class GamesListMap : EntityTypeConfiguration<GamesList>
    {
        public GamesListMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CodeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GamesList");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CodeName).HasColumnName("CodeName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
