using CoffeeLovers.DomainModels.Models;
using System.Threading.Tasks;

namespace CoffeeLovers.IRepositories
{
    public interface IAreaRepository : IRepository<Area>, IAsyncRepository<Area>
    {
        Task<Area> GetMaxOfprimaryKey();
    }
}
