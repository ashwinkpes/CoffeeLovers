using CoffeeLovers.APIModels;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IAreaService
    {
        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByName(string areaName);
    }
}
