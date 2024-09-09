using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Domain;

namespace StudentManagement.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentMaster> StudentMaster {  get; set; }

        public DbSet<TeacherMaster> TeacherMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentMaster>(entity =>
            {
                entity.HasKey(c => c.Id);

            });

            modelBuilder.Entity<TeacherMaster>(entity =>
            {
                entity.HasKey(c => c.Id);

            });
        }
    }
    
}
