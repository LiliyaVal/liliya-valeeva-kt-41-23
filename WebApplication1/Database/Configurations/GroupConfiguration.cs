using liliyavaleevaKt_41_23.Database.Helpers;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liliyavaleevaKt_41_23.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("cd_group");
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.GroupId)
                .HasColumnName("group_id")
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .HasColumnName("name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(g => g.Course)
                .HasColumnName("course")
                .HasColumnType(ColumnType.Int);

            builder.Property(g => g.SpecialtyId)
                .HasColumnName("specialty_id")
                .HasColumnType(ColumnType.Int);

            builder.Property(g => g.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool);

            // Связь: Группа принадлежит одной специальности
            builder.HasOne(g => g.Specialty)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.SpecialtyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}