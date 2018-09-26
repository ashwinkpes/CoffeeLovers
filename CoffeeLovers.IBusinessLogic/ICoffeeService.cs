using CoffeeLovers.APIModels;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface ICoffeeService
    {
        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByName(string areaName);

        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByDisplayId(string coffeeDisplayid);

        Task<(HttpStatusCode statusCode, IEnumerable<CoffeeDto> coffeeDto)> GetAllAreas(bool includeAreaOwners);

        Task<(HttpStatusCode statusCode, CoffeeDto areaDto)> CreateArea(AreaDto areaToAdd);

        Task<HttpStatusCode> UpdateArea(string coffeeDisplayid, List<PatchDto> patchDtos);

        Task<HttpStatusCode> DeleteArea(string coffeeDisplayid);
    }
}
