using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeLovers.DAL
{
    public static class CoffeeSeeder
    {
        public static void EnsureSeedData(this CoffeeDbContext db)
        {
            if (!db.Areas.Any())
            {
                db.Areas.Add(new Area
                {
                    AreaId = Guid.NewGuid(),
                    AreaName = "Koramangala",
                    CreatedBy = "System",
                    Createdtime = DateTime.Now,
                    PinCode = 570002                    
                });

              db.SaveChanges();
            }
        }
    }
}
