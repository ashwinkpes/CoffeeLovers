using CoffeeLovers.Common;
using CoffeeLovers.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.DAL
{
    public sealed class CoffeeDbContext : DbContext
    {
        private readonly ILogger<CoffeeDbContext> _logger;

        public CoffeeDbContext(DbContextOptions options) : this(options, new LoggerFactory().CreateLogger<CoffeeDbContext>())
        {
          
        }

        private CoffeeDbContext(DbContextOptions options, ILogger<CoffeeDbContext> logger) : base(options)
        {
            Database.Migrate();
            _logger = logger;
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

        public async Task<int> SaveChangesWithAuditTrial(string authId = Constants.CreatedBy)
        {
            AddAuditInfo(authId);
            return await base.SaveChangesAsync();
        }

        private void AddAuditInfo(string authId)
        {
            var timestamp = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && ((x.State == EntityState.Added) || (x.State == EntityState.Modified))))
            {
                if (entry.State == EntityState.Added)
                {
                    _logger.Log(LogLevel.Trace, $"Record Added By: [{authId}] on {timestamp}", entry.Entity);
                    ((BaseEntity)entry.Entity).CreatedBy = authId;
                    ((BaseEntity)entry.Entity).Createdtime = timestamp;
                }
                else if (entry.State == EntityState.Modified)
                {
                    _logger.Log(LogLevel.Trace, $"Record Updated By: [{authId}] on {timestamp}", entry.Entity);
                    ((BaseEntity)entry.Entity).UpdatedBy = authId;
                    ((BaseEntity)entry.Entity).Updatedtime = timestamp;
                }
            }
        }
    }
}
