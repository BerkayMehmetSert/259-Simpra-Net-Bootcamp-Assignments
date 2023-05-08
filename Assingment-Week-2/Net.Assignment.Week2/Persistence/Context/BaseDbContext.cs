using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Persistence.EntityConfigurations;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
