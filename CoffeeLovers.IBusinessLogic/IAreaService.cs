using CoffeeLovers.APIModels;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IAreaService
    {
        Task<(HttpStatusCode,AreaDto)> GetAreaByName(string areaName);
    }
}
