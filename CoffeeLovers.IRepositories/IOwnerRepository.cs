using CoffeeLovers.DomainModels.Models;
using System.Threading.Tasks;

namespace CoffeeLovers.IRepositories
{
    public interface IOwnerRepository : IRepository<Owner>, IAsyncRepository<Owner>
    {
        Task<Owner> GetMaxOfprimaryKey();
    }
}
