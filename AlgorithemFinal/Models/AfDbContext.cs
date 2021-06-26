using System.Collections.Generic;
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

            modelBuilder.Entity<User>()
                .HasAlternateKey(user => user.Code)
                .HasName("AlternateKey_Code");


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "مسعود",
                LastName = "پورغفار اقدم",
                Code = "975361004",
                Password = BCrypt.Net.BCrypt.HashPassword("test"),
                AdminId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "ریحانه",
                LastName = "زهرابی",
                Code = "965361004",
                Password = BCrypt.Net.BCrypt.HashPassword("test"),
                MasterId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "نرگس",
                LastName = "میرزایی",
                Code = "985361004",
                Password = BCrypt.Net.BCrypt.HashPassword("test"),
                StudentId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "طاها",
                LastName = "علیپور",
                Code = "985361003",
                Password = BCrypt.Net.BCrypt.HashPassword("test"),
                StudentId = 2
            });

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                UserId = 1
            });

            modelBuilder.Entity<Master>().HasData(new Master
            {
                Id = 1,
                UserId = 2
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                UserId = 3
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 2,
                UserId = 4
            });

            var days = new List<string> {"شنبه", "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه"};

            for (var i = 0; i < days.Count; i++)
            {
                modelBuilder.Entity<Day>().HasData(new Day
                {
                    Id = i + 1,
                    Label = days[i],
                    DayOfWeek = i
                });
            }

            modelBuilder.Entity<Bell>().HasData(new Bell
            {
                Id = 1,
                Label = "8-10",
                BellOfDay = 0
            });
            modelBuilder.Entity<Bell>().HasData(new Bell
            {
                Id = 2,
                Label = "10-12",
                BellOfDay = 1
            });
            modelBuilder.Entity<Bell>().HasData(new Bell
            {
                Id = 3,
                Label = "14-16",
                BellOfDay = 2
            });
            modelBuilder.Entity<Bell>().HasData(new Bell
            {
                Id = 4,
                Label = "16-18",
                BellOfDay = 3
            });
        }
    }
}