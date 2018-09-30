using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace CoffeeLovers.Repositories
{
    public class OwnerRepository : EfRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(CoffeeDbContext context) : base(context)
        {
            
        }

        public async Task<Owner> GetMaxOfPrimaryKey()
        {
            return await _dbContext.Owners.OrderByDescending(s => s.OwnerDisplayId).FirstOrDefaultAsync();
               
        }

    }
}
