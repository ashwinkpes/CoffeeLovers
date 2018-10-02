using CoffeeLovers.DomainModels.Models;

namespace CoffeeLovers.IRepositories
{
    public interface IOwnerConfirmationRepository : IRepository<OwnerConfirmation>, IAsyncRepository<OwnerConfirmation>
    {
    }
}