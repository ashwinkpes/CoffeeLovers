using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace CoffeeLovers.Repositories
{
    public class CoffeeRepository : EfRepository<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeDbContext context) : base(context)
        {
            
        }

        public async Task<Coffee> GetMaxOfPrimaryKey()
        {
            return await _dbContext.Coffees.OrderByDescending(s => s.CoffeeDisplayId).FirstOrDefaultAsync();
               
        }

    }
}
