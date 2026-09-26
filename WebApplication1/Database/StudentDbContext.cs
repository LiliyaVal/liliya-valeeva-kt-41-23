using liliyavaleevaKt_41_23.Database.Configurations;
using liliyavaleevaKt_41_23.Models;
using Microsoft.EntityFrameworkCore;

namespace liliyavaleevaKt_41_23.Database
{
    public class StudentDbContext : DbContext
    {
        // Таблицы
        public DbSet<Specialty> Specialtys { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
        }
    }
}

