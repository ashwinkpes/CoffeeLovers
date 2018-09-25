using CoffeeLovers.APIModels;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Logging;
using CoffeeLovers.Common.Mapping.DomainToApi;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IBusinessLogic;
using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.BusinessLogic
{
    public class AreaService : IAreaService
    {
        private readonly IAsyncRepository<Area> _areaAsynRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IAppLogger<AreaService> _logger;

        public AreaService(IAsyncRepository<Area> areaAsynRepository, IAreaRepository areaRepository, IAppLogger<AreaService> logger)
        {
            _areaAsynRepository = areaAsynRepository;
            _areaRepository = areaRepository;
            _logger = logger;
            CheckArguments();
        }

        public async Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByName(string areaName)
        {
            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByName started at {DateTime.UtcNow}");

            areaName.CheckArgumentIsNull(nameof(areaName));

            var areaDto = default(AreaDto);
            var statusCode = HttpStatusCode.NotFound;
          
            var areaSpec = new AreaWithAreaOwnersSpecification(areaName, false);

            var area = (await _areaAsynRepository.ListAsync(areaSpec).ConfigureAwait(false)).FirstOrDefault();
            if (area == null)
            {
                _logger.LogInformation($"No Area found for {areaName}");                
            }
            else
            {
                statusCode = HttpStatusCode.OK;
                areaDto = area.ToDto();
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByName completed at {DateTime.UtcNow}");

            return (statusCode, areaDto);
        }

        public async Task<(HttpStatusCode statusCode, IEnumerable<AreaDto> areaDtos)> GetAllAreas(bool includeAreaOwners)
        {
            _logger.LogInformation($"Service-GetAreaByName-Executing GetAllAreas started at {DateTime.UtcNow}");

            var areaDtos = default(IEnumerable<AreaDto>);
            var statusCode = HttpStatusCode.OK;

            var areaSpec = new AreaWithAreaOwnersSpecification(includeAreaOwners);
            var allAreas = (await _areaAsynRepository.ListAsync(areaSpec).ConfigureAwait(false));
            if (!allAreas.Any())
            {
                _logger.LogInformation($"No Areas found");
            }
            else
            {
                areaDtos = allAreas.ToDtos();
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing GetAllAreas completed at {DateTime.UtcNow}");

            return (statusCode, areaDtos);
        }

        public async Task<(HttpStatusCode statusCode, AreaDto areaDto)> CreateArea(AreaDto areaToAdd)
        {
            _logger.LogInformation($"Service-CreateArea-Executing CreateArea started at {DateTime.UtcNow}");
       
            var areaDto = areaToAdd;
            var statusCode = HttpStatusCode.Created;

            var areaSpec = new AreaWithAreaOwnersSpecification(areaToAdd.AreaName, false);

            var area = (await _areaAsynRepository.ListAsync(areaSpec).ConfigureAwait(false)).FirstOrDefault();
            if (area != null)
            {
                _logger.LogInformation($"Area with area name {areaToAdd.AreaName} already exists!!!");
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Area areaEntity = await _areaRepository.GetMaxOfprimaryKey();
                areaToAdd.AreaDisplayId = areaEntity.GetNextPrimaryKey();
                var areaAdded = await _areaAsynRepository.AddAsync(areaToAdd.ToEntity(true));
                statusCode = HttpStatusCode.OK;
                areaDto = areaAdded.ToDto();
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing CreateArea completed at {DateTime.UtcNow}");

            return (statusCode, areaDto);
        }

        private void CheckArguments()
        {
            _areaAsynRepository.CheckArgumentIsNull(nameof(_areaAsynRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
    }
}
