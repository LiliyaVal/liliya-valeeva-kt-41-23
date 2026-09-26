using liliyavaleevaKt_41_23.Database.Helpers;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liliyavaleevaKt_41_23.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("cd_student");
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.StudentId)
                .HasColumnName("student_id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                .HasColumnName("first_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(s => s.LastName)
                .HasColumnName("last_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(s => s.GroupId)
                .HasColumnName("group_id")
                .HasColumnType(ColumnType.Int);

            builder.Property(s => s.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool);

            // Связь: Студент принадлежит одной группе
            builder.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}