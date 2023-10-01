using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;

namespace Universites.Repositories.Models
{
    public class UniversitiesContext : DbContext, IUniversitiesContext
    {
        public UniversitiesContext(DbContextOptions<UniversitiesContext> options) : base(options) { }

        public DbSet<University> Universities { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("", b => b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(b => b.University)
                .WithMany(a => a.Departments)
                .HasForeignKey(b => b.UniversityID)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Course>()
                .HasOne(b => b.Department)
                .WithMany(a => a.Courses)
                .HasForeignKey(b => b.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
