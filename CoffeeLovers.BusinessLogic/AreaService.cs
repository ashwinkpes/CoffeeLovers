using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IBusinessLogic;
using CoffeeLovers.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLovers.BusinessLogic
{
    public class AreaService : IAreaService
    {
        public AreaService(IAsyncRepository<Area> areaRepository)
        {

        }

        public Task<Area> GetAreaByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
