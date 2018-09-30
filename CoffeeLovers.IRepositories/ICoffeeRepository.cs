using CoffeeLovers.DomainModels.Models;
using System.Threading.Tasks;

namespace CoffeeLovers.IRepositories
{
    public interface ICoffeeRepository : IRepository<Coffee>, IAsyncRepository<Coffee>
    {
        Task<Coffee> GetMaxOfPrimaryKey();
    }
}
