using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using System;
using System.Linq;

namespace CoffeeLovers.DAL
{
    public static class CoffeeSeeder
    {
        public static void EnsureSeedData(this CoffeeDbContext db, SeedData seedData)
        {
            seedData.CheckArgumentIsNull(nameof(seedData));

            if (!db.Roles.Any())
            {
                db.Roles.AddRange(seedData.Roles);
            }

            if (!db.Areas.Any())
            {
              db.Areas.AddRange(seedData.Areas);            
            }

            if (!db.Owners.Any())
            {
                db.Owners.AddRange(seedData.Owners);
            }

            if (!db.Coffees.Any())
            {
                seedData.Coffees.ToList().ForEach(x => { x.validTo = x.validFrom = DateTime.Now; });
                db.Coffees.AddRange(seedData.Coffees);               
            }

            db.SaveChangesWithAuditTrial().GetAwaiter().GetResult();         
        }
    }
}
