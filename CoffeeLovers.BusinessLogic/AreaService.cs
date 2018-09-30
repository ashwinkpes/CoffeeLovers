using CoffeeLovers.Common;
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
using CoffeeLovers.APIModels.Area;

namespace CoffeeLovers.BusinessLogic
{
    public class AreaService : IAreaService
    {

        #region --Private variables--
        private readonly IAreaRepository _areaRepository;
        private readonly IAppLogger<AreaService> _logger; 
        #endregion

        #region --Constructor--
        public AreaService(IAreaRepository areaRepository, IAppLogger<AreaService> logger)
        {
            _areaRepository = areaRepository;
            _logger = logger;
            CheckArguments();
        }
        #endregion

        #region --Read Operations--
        public async Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByDisplayId(string areaDisplayId)
        {
            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByDisplayId started at {DateTime.UtcNow}");

            areaDisplayId.CheckArgumentIsNull(nameof(areaDisplayId));

            var areaDto = default(AreaDto);
            var statusCode = HttpStatusCode.NotFound;

            var areaSpec = new AreaWithAreaOwnersSpecification(false, areaDisplayId);

            var area = (await _areaRepository.ListAsync(areaSpec).ConfigureAwait(false)).FirstOrDefault();
            if (area == null)
            {
                _logger.LogInformation($"No Area found with area display id  {areaDisplayId}");
            }
            else
            {
                statusCode = HttpStatusCode.OK;
                areaDto = area.ToDto();
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByDisplayId completed at {DateTime.UtcNow}");

            return (statusCode, areaDto);
        }

        public async Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetAreaByName(string areaName)
        {
            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByName started at {DateTime.UtcNow}");

            areaName.CheckArgumentIsNull(nameof(areaName));

            var areaDto = default(AreaDto);
            var statusCode = HttpStatusCode.NotFound;

            var areaSpec = new AreaWithAreaOwnersSpecification(areaName, false);

            var area = (await _areaRepository.ListAsync(areaSpec).ConfigureAwait(false)).FirstOrDefault();
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
            _logger.LogInformation($"Service-GetAllAreas-Executing GetAllAreas started at {DateTime.UtcNow}");

            var areaDtos = default(IEnumerable<AreaDto>);
            var statusCode = HttpStatusCode.OK;

            var areaSpec = new AreaWithAreaOwnersSpecification(includeAreaOwners);
            var allAreas = (await _areaRepository.ListAsync(areaSpec).ConfigureAwait(false));
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

        #endregion

        #region --Add operations--
        public async Task<(HttpStatusCode statusCode, string areaDisplayId)> CreateArea(AreaDto areaToAdd)
        {
            _logger.LogInformation($"Service-CreateArea-Executing CreateArea started at {DateTime.UtcNow}");

            var areaDisplayId = string.Empty;
            var statusCode = HttpStatusCode.Created;

            var areaSpec = new AreaWithAreaOwnersSpecification(areaToAdd.AreaName, false);

            var area = (await _areaRepository.ListAsync(areaSpec).ConfigureAwait(false)).FirstOrDefault();
            if (area != null)
            {
                _logger.LogInformation($"Area with area name {areaToAdd.AreaName} already exists!!!");
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Area areaEntity = await _areaRepository.GetMaxOfPrimaryKey();
                areaToAdd.AreaDisplayId = areaEntity.GetNextPrimaryKey();
                await _areaRepository.AddAsync(areaToAdd.ToEntity(true)).ConfigureAwait(false);
                await _areaRepository.SaveAllwithAudit().ConfigureAwait(false);
                statusCode = HttpStatusCode.OK;
                areaDisplayId = areaToAdd.AreaDisplayId;
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing CreateArea completed at {DateTime.UtcNow}");

            return (statusCode, areaDisplayId);
        }
        #endregion

        #region --Update Operations--
        public async Task<HttpStatusCode> UpdateArea(string areaDisplayId, List<PatchDto> patchDtos)
        {
            var statusCode = HttpStatusCode.NoContent;

            areaDisplayId.CheckArgumentIsNull(nameof(areaDisplayId));

            _logger.LogInformation($"Service-CreateArea-Executing UpdateArea started at {DateTime.UtcNow}");

            _logger.LogInformation($"Service-CreateArea-Executing get the area to be patched {DateTime.UtcNow}");

            var areaDromDb = await _areaRepository.FindAsync(s => s.AreaDisplayId == areaDisplayId && s.IsActive).ConfigureAwait(false);

            if (areaDromDb == null)
            {
                _logger.LogInformation($"No Area found with areaDisplayId {areaDisplayId}");
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                 _areaRepository.ApplyPatch(areaDromDb, patchDtos); 
                await _areaRepository.SaveAllwithAudit().ConfigureAwait(false);
            }

            return statusCode;
        }
        #endregion

        #region --Delete Operations--
        public async Task<HttpStatusCode> DeleteArea(string areaDisplayId)
        {
            var statusCode = HttpStatusCode.NoContent;

            areaDisplayId.CheckArgumentIsNull(nameof(areaDisplayId));

            _logger.LogInformation($"Service-CreateArea-Executing DeleteArea started at {DateTime.UtcNow}");

            var areaDromDb = await _areaRepository.FindAsync(s => s.AreaDisplayId == areaDisplayId).ConfigureAwait(false);

            if (areaDromDb == null)
            {
                _logger.LogInformation($"No Area found with areaDisplayId {areaDisplayId}");
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                _areaRepository.SoftDeleteAsync(areaDromDb);
                await _areaRepository.SaveAllwithAudit().ConfigureAwait(false);
            }

            return statusCode;
        }
        #endregion

        #region --Private Methods--
        private void CheckArguments()
        {
            _areaRepository.CheckArgumentIsNull(nameof(_areaRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        } 
        #endregion
    }
}
