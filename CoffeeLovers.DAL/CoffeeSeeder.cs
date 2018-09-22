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

            seedData.Areas.ToList().ForEach(a => { a.CreatedBy = "System"; a.Createdtime = DateTime.UtcNow; });
            seedData.Coffees.ToList().ForEach(a => { a.CreatedBy = "System"; a.Createdtime = DateTime.UtcNow; a.validFrom = DateTime.UtcNow; a.validTo = DateTime.MaxValue; });
            seedData.Owners.ToList().ForEach(a => { a.CreatedBy = "System"; a.Createdtime = DateTime.UtcNow; });

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
                db.Coffees.AddRange(seedData.Coffees);               
            }

            db.SaveChanges();
        }

    }
}
