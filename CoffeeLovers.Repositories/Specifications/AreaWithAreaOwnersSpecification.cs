using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.Repositories.Core;
using System;

namespace CoffeeLovers.Repositories.Specifications
{
    public sealed class AreaWithAreaOwnersSpecification : BaseSpecification<Area>
    {
        public AreaWithAreaOwnersSpecification(Guid areaId, bool includeAreaOwners)
           : base(b => b.AreaId == areaId)
        {
            if (includeAreaOwners) AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(string areaName, bool includeAreaOwners)
          : base(b => b.AreaName == areaName && b.IsActive)
        {
            if (includeAreaOwners)  AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(int pinCode, bool includeAreaOwners)
        : base(b => b.PinCode == pinCode)
        {
            if (includeAreaOwners)  AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(bool includeAreaOwners) : base(b => !string.IsNullOrEmpty(b.AreaName) && b.IsActive)
        {
            if (includeAreaOwners) AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(bool includeAreaOwners, string areaDisplayId) : base(b => b.AreaDisplayId == areaDisplayId && b.IsActive)
        {
            if (includeAreaOwners) AddInclude(b => b.AreaOwners);
        }

    }
}
