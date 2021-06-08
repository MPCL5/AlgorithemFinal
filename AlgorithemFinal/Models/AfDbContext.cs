using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
