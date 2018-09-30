using CoffeeLovers.APIModels.Area;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IAreaService
    {
        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByName(string areaName);

        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByDisplayId(string areaDisplayId);

        Task<(HttpStatusCode statusCode, IEnumerable<AreaDto> areaDtos)> GetAllAreas(bool includeAreaOwners);

        Task<(HttpStatusCode statusCode, string areaDisplayId)> CreateArea(AreaDto areaToAdd);

        Task<HttpStatusCode> UpdateArea(string areaDisplayId, List<PatchDto> patchDtos);

        Task<HttpStatusCode> DeleteArea(string areaDisplayId);
    }
}