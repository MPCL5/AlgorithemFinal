using Microsoft.EntityFrameworkCore;

namespace AlgorithemFinal.Models
{
    public class AfDbContext : DbContext
    {
        public AfDbContext(DbContextOptions options) : base(options)
        {
        }

        public AfDbContext()
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Bell> Bells { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<TimeTableBell> TimeTableBells { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Admin)
                .WithOne(p => p.User)
                .HasForeignKey<Admin>(p => p.UserId);
            
            modelBuilder.Entity<User>()
                .HasOne(p => p.Master)
                .WithOne(p => p.User)
                .HasForeignKey<Master>(p => p.UserId);
            
            modelBuilder.Entity<User>()
                .HasOne(p => p.Student)
                .WithOne(p => p.User)
                .HasForeignKey<Student>(p => p.UserId);
            
            // modelBuilder.Entity<Admin>()
            //     .HasOne(p => p.User)
            //     .WithOne(p => p.Admin)
            //     .HasForeignKey<User>(p => p.AdminId);
            //
            // modelBuilder.Entity<Master>()
            //    .HasOne(p => p.User)
            //    .WithOne(p => p.Master)
            //    .HasForeignKey<User>(p => p.MasterId);
            //
            // modelBuilder.Entity<Student>()
            //    .HasOne(p => p.User)
            //    .WithOne(p => p.Student)
            //    .HasForeignKey<User>(p => p.StudentId);
            
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Masoud",
                LastName = "Poorghaffar",
                Code = "975361004",
                Password = "test",
                AdminId = 1
            });

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                UserId = 1
            });
        }
    }
}