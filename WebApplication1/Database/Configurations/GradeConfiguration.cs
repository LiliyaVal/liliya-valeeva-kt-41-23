using liliyavaleevaKt_41_23.Database.Helpers;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liliyavaleevaKt_41_23.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("cd_grade");
            builder.HasKey(g => g.GradeId);

            builder.Property(g => g.GradeId)
                .HasColumnName("grade_id")
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Value)
                .HasColumnName("value")
                .HasColumnType(ColumnType.Int);

            builder.Property(g => g.StudentId)
                .HasColumnName("student_id")
                .HasColumnType(ColumnType.Int);

            builder.Property(g => g.DisciplineId)
                .HasColumnName("discipline_id")
                .HasColumnType(ColumnType.Int);

            // Связь: Оценка принадлежит одному студенту
            builder.HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь: Оценка по одной дисциплине
            builder.HasOne(g => g.Discipline)
                .WithMany(d => d.Grades)
                .HasForeignKey(g => g.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}