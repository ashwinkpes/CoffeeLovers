using CoffeeLovers.DomainModels.Models;

namespace CoffeeLovers.IRepositories
{
    public interface IAreaRepository : IRepository<Area>, IAsyncRepository<Area>
    {
    }
}
