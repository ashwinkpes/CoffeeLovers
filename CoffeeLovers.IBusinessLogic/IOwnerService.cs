using CoffeeLovers.APIModels.Owner;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IOwnerService
    {
        Task<(HttpStatusCode statusCode, string ownerId, Guid confirmationToken, string ownerEmailId, string fullName)> RegisterOwner(AddOwnerDto addOwnerDto);
    }
}