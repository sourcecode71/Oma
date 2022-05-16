using Microsoft.EntityFrameworkCore;
using Oma.Data.Models.Common;
using Oma.Data.Models.Vendor;

namespace Oma.Data.Repository.DAL
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<States> State { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Supplier>()
            .HasOne(p => p.States)
            .WithMany(c => c.Suppliers)
            .HasForeignKey(p => p.StateId);

            modelBuilder.Entity<States>()
            .HasMany(t => t.Suppliers)
            .WithOne(p => p.States)
            .HasForeignKey(p => p.StateId);

        }
    }
}
