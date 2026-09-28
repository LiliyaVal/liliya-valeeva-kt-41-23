using liliyavaleevaKt_41_23.Database.Helpers;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liliyavaleevaKt_41_23.Database.Configurations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("specialty");
            builder.HasKey(s => s.SpecialtyId);

            builder.Property(s => s.SpecialtyId)
                .HasColumnName("specialty_id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Title)
                .HasColumnName("title")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(200);

            builder.Property(s => s.Code)
                .HasColumnName("code")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50);
        }
    }
}