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
        Task<(HttpStatusCode statusCode, OwnerDto ownerDto)> RegisterOwner(AddEditOwnerDto addOwnerDto, bool isAdminUser);
    }
}
