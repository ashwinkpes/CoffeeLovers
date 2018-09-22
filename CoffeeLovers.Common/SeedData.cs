using CoffeeLovers.DomainModels.Models;
using System.Collections.Generic;

namespace CoffeeLovers.Common
{
    public sealed class SeedData
    {
        public IEnumerable<Area> Areas { get; set; }

        public IEnumerable<Owner> Owners { get; set; }

        public IEnumerable<Coffee> Coffees { get; set; }

    }
}
