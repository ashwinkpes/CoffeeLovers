using CoffeeLovers.APIModels.Owner;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IOwnerService
    {
        Task<(HttpStatusCode statusCode, string ownerId)> RegisterOwner(AddOwnerDto addOwnerDto);
    }
}