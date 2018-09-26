﻿using CoffeeLovers.APIModels;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface IAreaService
    {
        Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByName(string areaName);

        Task<(HttpStatusCode statusCode, IEnumerable<AreaDto> areaDtos)> GetAllAreas(bool includeAreaOwners);

        Task<(HttpStatusCode statusCode, AreaDto areaDto)> CreateArea(AreaDto areaToAdd);

        Task<HttpStatusCode> UpdateArea(string areaDisplayId, List<PatchDto> patchDtos);
    }
}
