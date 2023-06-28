using ChildCentre.Slynchogled.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChildCentre.Slynchogled.Data.Context
{
    public class ChildCentreContext : DbContext
    {
        public ChildCentreContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<ActiveChild> ActiveChildren { get; set; }
        public DbSet<ActiveChildHistory> ActiveChildrenHistory { get; set; }
    }
}