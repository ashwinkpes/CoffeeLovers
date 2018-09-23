using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.IRepositories
{
    public interface IAreaRepository : IRepository<Area>, IAsyncRepository<Area>
    {
    }
}
