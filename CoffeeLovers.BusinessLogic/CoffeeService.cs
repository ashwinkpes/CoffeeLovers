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

        public Task<(HttpStatusCode statusCode, CoffeeDto areaDto)> CreateArea(AreaDto areaToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> DeleteArea(string coffeeDisplayid)
        {
            throw new NotImplementedException();
        }

        public Task<(HttpStatusCode statusCode, IEnumerable<CoffeeDto> coffeeDto)> GetAllAreas(bool includeAreaOwners)
        {
            throw new NotImplementedException();
        }

        public Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByDisplayId(string coffeeDisplayid)
        {
            throw new NotImplementedException();
        }

        public Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByName(string areaName)
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
    }
}
