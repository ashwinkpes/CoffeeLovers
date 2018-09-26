using CoffeeLovers.APIModels;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface ICoffeeService
    {
        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetCoffeeByName(string areaName);

        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetCoffeeByDisplayId(string coffeeDisplayid);

        Task<(HttpStatusCode statusCode, IEnumerable<AreaDto> areaDtos)> GetAllAreas(bool includeAreaOwners);

        Task<(HttpStatusCode statusCode, AreaDto areaDto)> CreateArea(AreaDto areaToAdd);

        Task<HttpStatusCode> UpdateArea(string coffeeDisplayid, List<PatchDto> patchDtos);

        Task<HttpStatusCode> DeleteArea(string coffeeDisplayid);
    }
}
