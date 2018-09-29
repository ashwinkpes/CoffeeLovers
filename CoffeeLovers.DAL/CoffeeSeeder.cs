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

            AddAuditDetails(seedData);

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
                db.Coffees.AddRange(seedData.Coffees);               
            }

            db.SaveChanges();
        }

        public static void AddAuditDetails(SeedData seedData)
        {
            seedData.Areas.ToList().ForEach(a => 
            {
                a.CreatedBy = Constants.CreatedBy;
                a.Createdtime = DateTime.UtcNow;
            });

            seedData.Coffees.ToList().ForEach(a => 
            {
                a.CreatedBy = Constants.CreatedBy;
                a.Createdtime = a.validFrom  = a.validTo =  DateTime.UtcNow;             
            });

            seedData.Owners.ToList().ForEach(a => 
            {
                a.CreatedBy = Constants.CreatedBy;
                a.Createdtime = DateTime.UtcNow;
            });

            seedData.Roles.ToList().ForEach(a => 
            {
                a.CreatedBy = Constants.CreatedBy;               
                a.Createdtime =  a.validFrom = a.validTo = DateTime.UtcNow;              
            });
        }

    }
}
