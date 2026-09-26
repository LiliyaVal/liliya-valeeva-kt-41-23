using liliyavaleevaKt_41_23.Database.Helpers;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liliyavaleevaKt_41_23.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("cd_discipline");
            builder.HasKey(d => d.DisciplineId);

            builder.Property(d => d.DisciplineId)
                .HasColumnName("discipline_id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(200);

            builder.Property(d => d.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool);
        }
    }
}