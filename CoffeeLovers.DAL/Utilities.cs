using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.DAL
{
    public sealed class Utilities
    {
                
        public Utilities()
        {

        }

        public IList<Area> GetAllAlreas()
        {
            var areas = new List<Area>
            {
               new Area { AreaId = Guid.NewGuid(), AreaName = ""}

            };

            return areas;
        }
       
    }
}
