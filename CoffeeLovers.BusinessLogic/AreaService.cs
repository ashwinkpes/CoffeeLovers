using CoffeeLovers.APIModels;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Logging;
using CoffeeLovers.Common.Mapping.DomainToApi;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IBusinessLogic;
using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories.Specifications;
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
        }

        public async Task<(HttpStatusCode, AreaDto)> GetAreaByName(string areaName)
        {
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

            return (statusCode, areaDto);
        }
    }
}
