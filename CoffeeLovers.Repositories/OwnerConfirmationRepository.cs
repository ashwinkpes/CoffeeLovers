using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;

namespace CoffeeLovers.Repositories
{
    public class OwnerConfirmationRepository : EfRepository<OwnerConfirmation>, IOwnerConfirmationRepository
    {
        public OwnerConfirmationRepository(CoffeeDbContext context) : base(context)
        {
        }
    }
}