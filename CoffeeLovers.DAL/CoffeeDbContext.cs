using CoffeeLovers.DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeLovers.DAL
{
    public sealed class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AreaOwner> AreaOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
        }
    }
}
