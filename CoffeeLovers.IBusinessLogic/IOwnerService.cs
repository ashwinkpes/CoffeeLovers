using CoffeeLovers.APIModels;
using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IOwnerService
    {
        Task<(HttpStatusCode statusCode, string ownerId)> RegisterOwner(AddEditOwnerDto addOwnerDto);
    }
}
