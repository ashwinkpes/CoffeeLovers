using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Repositories
{
    public class AreaRepository : EfRepository<Area>, IAreaRepository
    {
        public AreaRepository(CoffeeDbContext context) : base(context)
        {
        }
    }
}
