using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.IBusinessLogic;
using System;
using System.Linq;

namespace CoffeeLovers.DAL
{
    public static class CoffeeSeeder
    {
        public static void EnsureSeedData(this CoffeeDbContext db, SeedData seedData, ISecurityService securityService)
        {
            seedData.CheckArgumentIsNull(nameof(seedData));

            if (!db.Roles.Any())
            {
                seedData.Roles.ToList().ForEach(x => { x.ValidTo = x.ValidFrom = DateTime.Now; });
                db.Roles.AddRange(seedData.Roles);
            }

            if (!db.Areas.Any())
            {
              db.Areas.AddRange(seedData.Areas);            
            }

            if (!db.Owners.Any())
            {
                seedData.Owners.ToList().ForEach(x => { x.Password = securityService.GetSha256Hash(seedData.UserInitalizePassword); });
                db.Owners.AddRange(seedData.Owners);
            }

            if (!db.Coffees.Any())
            {
                seedData.Coffees.ToList().ForEach(x => { x.ValidTo = x.ValidFrom = DateTime.Now; });
                db.Coffees.AddRange(seedData.Coffees);               
            }

            db.SaveChangesWithAuditTrial().GetAwaiter().GetResult();         
        }
    }
}
