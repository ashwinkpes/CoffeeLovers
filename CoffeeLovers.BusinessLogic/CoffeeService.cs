using CoffeeLovers.APIModels;
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

namespace CoffeeLovers.BusinessLogic
{
    public class CoffeeService : ICoffeeService
    {
       
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IAppLogger<CoffeeService> _logger;

        public CoffeeService(ICoffeeRepository coffeeRepository, IAppLogger<CoffeeService> logger)
        {
            _coffeeRepository = coffeeRepository;
            _logger = logger;
            CheckArguments();
        }

        public Task<(HttpStatusCode statusCode, AreaDto areaDto)> CreateArea(AreaDto areaToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> DeleteArea(string coffeeDisplayid)
        {
            throw new NotImplementedException();
        }

        public Task<(HttpStatusCode statusCode, IEnumerable<AreaDto> areaDtos)> GetAllAreas(bool includeAreaOwners)
        {
            throw new NotImplementedException();
        }

        public async Task<(HttpStatusCode statusCode, CoffeeDto areaDto)> GetCoffeeByDisplayId(string coffeeDisplayid)
        {
            _logger.LogInformation($"Service-GetAreaByName-Executing GetCoffeeByDisplayId started at {DateTime.UtcNow}");

            coffeeDisplayid.CheckArgumentIsNull(nameof(coffeeDisplayid));

            var areaDto = default(CoffeeDto);
            var statusCode = HttpStatusCode.NotFound;

            var coffeeSpec = new CoffeeWithAreasSpecification(false, coffeeDisplayid);

            var coffee = (await _coffeeRepository.ListAsync(coffeeSpec).ConfigureAwait(false)).FirstOrDefault();
            if (coffee == null)
            {
                _logger.LogInformation($"No coffee found with area display id  {coffeeDisplayid}");
            }
            else
            {
                statusCode = HttpStatusCode.OK;
                areaDto = coffee.ToDto();
            }

            _logger.LogInformation($"Service-GetAreaByName-Executing GetAreaByDisplayId completed at {DateTime.UtcNow}");

            return (statusCode, areaDto);
        }

        public Task<(HttpStatusCode statusCode, AreaDto areaDto)> GetCoffeeByName(string areaName)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> UpdateArea(string coffeeDisplayid, List<PatchDto> patchDtos)
        {
            throw new NotImplementedException();
        }

        private void CheckArguments()
        {
            _coffeeRepository.CheckArgumentIsNull(nameof(_coffeeRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }

        Task<(HttpStatusCode statusCode, AreaDto areaDto)> ICoffeeService.GetCoffeeByDisplayId(string coffeeDisplayid)
        {
            throw new NotImplementedException();
        }
    }
}
