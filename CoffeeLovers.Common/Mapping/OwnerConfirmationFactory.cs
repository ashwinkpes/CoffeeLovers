using CoffeeLovers.DomainModels.Models;
using System;

namespace CoffeeLovers.Common.Mapping
{
    public static class OwnerConfirmationFactory
    {
        public static void GenerateLinkAndToken(this OwnerConfirmation ownerConfirmation, Guid OwnerId)
        {
            ownerConfirmation.ValidFrom = DateTime.UtcNow;
            ownerConfirmation.ValidTo = DateTime.UtcNow.AddHours(1);
            ownerConfirmation.OwnerConfirmationId = Guid.NewGuid();
            ownerConfirmation.confirmationToken = Guid.NewGuid();
            ownerConfirmation.OwnerId = OwnerId;            
        }
    }
}