using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Repositories.Specifications
{
    public sealed class AreaWithAreaOwnersSpecification : BaseSpecification<Area>
    {
        public AreaWithAreaOwnersSpecification(Guid areaId)
           : base(b => b.AreaId == areaId)
        {
            AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(string areaName)
          : base(b => b.AreaName == areaName)
        {
            AddInclude(b => b.AreaOwners);
        }

        public AreaWithAreaOwnersSpecification(int pinCode)
        : base(b => b.PinCode == pinCode)
        {
            AddInclude(b => b.AreaOwners);
        }
    }
}
