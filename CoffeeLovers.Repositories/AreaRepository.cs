using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;

namespace CoffeeLovers.Repositories
{
    public class AreaRepository : EfRepository<Area>, IAreaRepository
    {
        public AreaRepository(CoffeeDbContext context) : base(context)
        {
        }
    }
}
