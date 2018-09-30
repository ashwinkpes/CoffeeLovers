using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace CoffeeLovers.Repositories
{
    public class AreaRepository : EfRepository<Area>, IAreaRepository
    {
        public AreaRepository(CoffeeDbContext context) : base(context)
        {
            
        }

        public async Task<Area> GetMaxOfPrimaryKey()
        {
            return await _dbContext.Areas.OrderByDescending(s => s.AreaDisplayId).FirstOrDefaultAsync();
               
        }

    }
}
