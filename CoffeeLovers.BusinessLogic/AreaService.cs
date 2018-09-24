using CoffeeLovers.APIModels;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Logging;
using CoffeeLovers.Common.Mapping.DomainToApi;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IBusinessLogic;
using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories.Specifications;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.BusinessLogic
{
    public class AreaService : IAreaService
    {
        private readonly IAsyncRepository<Area> _areaRepository;
        private readonly IAppLogger<AreaService> _logger;

        public AreaService(IAsyncRepository<Area> areaRepository, IAppLogger<AreaService> logger)
        {
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

        private void CheckArguments()
        {
            _areaRepository.CheckArgumentIsNull(nameof(_areaRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
    }
}
