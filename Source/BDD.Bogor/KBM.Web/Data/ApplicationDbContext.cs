using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KBM.Web.Models;
using Microsoft.Data.Sqlite;

namespace KBM.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public static string DBName {set;get;}
        public DbSet<UserProfile> DataUser { get; set; }
        public DbSet<Kelas> DataKelas { get; set; }
        public DbSet<MataPelajaran> DataPelajaran { get; set; }
        public DbSet<Content> DataContent { get; set; }
        public DbSet<Ujian> DataUjian { get; set; }
        public DbSet<UserPerKelas> MapUserKelas { get; set; }
        public DbSet<KelasPerMataPelajaran> MapKelasPelajaran { get; set; }
        public DbSet<MataPelajaranPerContent> MapPelajaranContent { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = DBName };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            builder.Entity<Student>()
                   .HasMany<Course>(s => s.Courses)
                   .WithMany(c => c.Students)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("StudentRefId");
                       cs.MapRightKey("CourseRefId");
                       cs.ToTable("StudentCourse");
                   });*/
            base.OnModelCreating(builder);
           
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
