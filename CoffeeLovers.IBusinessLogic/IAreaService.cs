using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IAreaService
    {
        Task<Area> GetAreaByName(string name);
    }
}
