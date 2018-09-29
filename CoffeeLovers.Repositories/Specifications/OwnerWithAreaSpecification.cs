using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.Repositories.Core;
using System;

namespace CoffeeLovers.Repositories.Specifications
{
    public sealed class OwnerWithAreaSpecification : BaseSpecification<Owner>
    {
        public OwnerWithAreaSpecification(Guid ownerId, bool includeAreas)
           : base(b => b.OwnerId == ownerId)
        {
            if (includeAreas) AddInclude(b => b.AreaOwners);
        }

        public OwnerWithAreaSpecification(string fullName, bool includeAreas)
          : base(b => b.FullName.Contains(fullName))
        {
            if (includeAreas) AddInclude(b => b.AreaOwners);
        }

        public OwnerWithAreaSpecification(bool includeAreas, string roleName)
          : base(b => b.Role.RoleName == roleName)
        {
            if (includeAreas) AddInclude(b => b.AreaOwners);
        }

        public OwnerWithAreaSpecification(string emailId)
         : base(b => b.EmailId == emailId)
        {
            
        }
    }
}
