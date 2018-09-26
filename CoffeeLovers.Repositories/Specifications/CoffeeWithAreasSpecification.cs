using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.Repositories.Core;
using System;

namespace CoffeeLovers.Repositories.Specifications
{
    public sealed class CoffeeWithAreasSpecification : BaseSpecification<Coffee>
    {
        public CoffeeWithAreasSpecification(Guid coffeeId, bool includeAreas)
           : base(b => b.CoffeeId == coffeeId)
        {
            if (includeAreas) AddInclude(b => b.CoffeeAreas);
        }

        public CoffeeWithAreasSpecification(string coffeeName, bool includeAreas)
          : base(b => b.CoffeeName == coffeeName)
        {
            if (includeAreas)  AddInclude(b => b.CoffeeAreas);
        }

        public CoffeeWithAreasSpecification(bool includeAreas) : base(b => !string.IsNullOrEmpty(b.CoffeeName))
        {
            if (includeAreas) AddInclude(b => b.CoffeeAreas);
        }

        public CoffeeWithAreasSpecification(bool includeAreas, string coffeeDisplayId) : base(b => b.CoffeeDisplayId == coffeeDisplayId)
        {
            if (includeAreas) AddInclude(b => b.CoffeeAreas);
        }

    }
}
