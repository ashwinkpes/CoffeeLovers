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
using CoffeeLovers.APIModels.Coffee;

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

        public async Task<(HttpStatusCode statusCode, string coffeeId)> CreateCoffee(AddCoffeeDto cofeeToAdd)
        {
            _logger.LogInformation($"Service-CreateCoffee-Executing CreateCoffee started at {DateTime.UtcNow}");

            var coffeeId = string.Empty;
            var statusCode = HttpStatusCode.Created;
            CoffeeDto cofeeToStrore = default(CoffeeDto);

            var coffeeSpec = new CoffeeWithAreasSpecification(cofeeToAdd.CoffeeName, false);

            var cofee = (await _coffeeRepository.ListAsync(coffeeSpec).ConfigureAwait(false)).FirstOrDefault();
            if (cofee != null)
            {
                _logger.LogInformation($"cofee with cofee name {cofeeToAdd.CoffeeName} already exists!!!");
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Coffee cofeeEntity = await _coffeeRepository.GetMaxOfprimaryKey();
                string newCoffeeDisplayId = cofeeEntity.GetNextPrimaryKey();

                cofeeToStrore = new CoffeeDto(newCoffeeDisplayId);
                cofeeToStrore.CoffeeName = cofeeToAdd.CoffeeName;             

                await _coffeeRepository.AddAsync(cofeeToStrore.ToEntity(true)).ConfigureAwait(false);
                await _coffeeRepository.SaveAllwithAudit().ConfigureAwait(false);
                statusCode = HttpStatusCode.OK;
                coffeeId = newCoffeeDisplayId;
            }

            _logger.LogInformation($"Service-CreateCoffee-Executing CreateCoffee completed at {DateTime.UtcNow}");

            return (statusCode, coffeeId);
        }

        public async Task<HttpStatusCode> DeleteCoffee(string coffeeDisplayid)
        {
            var statusCode = HttpStatusCode.NoContent;

            coffeeDisplayid.CheckArgumentIsNull(nameof(coffeeDisplayid));

            _logger.LogInformation($"Service-DeleteCoffee-Executing DeleteCoffee started at {DateTime.UtcNow}");

            var coffeeFromDb = await _coffeeRepository.FindAsync(s => s.CoffeeDisplayId == coffeeDisplayid).ConfigureAwait(false);

            if (coffeeFromDb == null)
            {
                _logger.LogInformation($"No Coffee found with coffee id  {coffeeDisplayid}");
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                _coffeeRepository.SoftDeleteAsync(coffeeFromDb);
                await _coffeeRepository.SaveAllwithAudit().ConfigureAwait(false);
            }

            return statusCode;
        }

        public async Task<(HttpStatusCode statusCode, IEnumerable<CoffeeDto> coffeeDtos)> GetAllCoffees(bool includeCofeeAreas)
        {
            _logger.LogInformation($"Service-GetAllCoffees-Executing GetAllCoffees started at {DateTime.UtcNow}");

            var coffeeDtos = default(IEnumerable<CoffeeDto>);
            var statusCode = HttpStatusCode.OK;

            var coffeeSpec = new CoffeeWithAreasSpecification(includeCofeeAreas);

            var allCoffees = (await _coffeeRepository.ListAsync(coffeeSpec).ConfigureAwait(false));
            if (!allCoffees.Any())
            {
                _logger.LogInformation($"No coffees found");
            }
            else
            {
                coffeeDtos = allCoffees.ToDtos();
            }

            _logger.LogInformation($"Service-GetAllCoffees-Executing GetAllCoffees completed at {DateTime.UtcNow}");

            return (statusCode, coffeeDtos);
        }

        public async Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByDisplayId(string coffeeDisplayid)
        {
            _logger.LogInformation($"Service-GetCoffeeByDisplayId-Executing GetCoffeeByDisplayId started at {DateTime.UtcNow}");

            coffeeDisplayid.CheckArgumentIsNull(nameof(coffeeDisplayid));

            var coffeeDto = default(CoffeeDto);
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
                coffeeDto = coffee.ToDto();
            }

            _logger.LogInformation($"Service-GetCoffeeByDisplayId-Executing GetCoffeeByDisplayId completed at {DateTime.UtcNow}");

            return (statusCode, coffeeDto);
        }

        public async Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByName(string cofeeName)
        {
            _logger.LogInformation($"Service-GetCoffeeByName-Executing GetCoffeeByName started at {DateTime.UtcNow}");

            cofeeName.CheckArgumentIsNull(nameof(cofeeName));

            var coffeeDto = default(CoffeeDto);
            var statusCode = HttpStatusCode.NotFound;

            var coffeeSpec = new CoffeeWithAreasSpecification(cofeeName, false);

            var coffee = (await _coffeeRepository.ListAsync(coffeeSpec).ConfigureAwait(false)).FirstOrDefault();
            if (coffee == null)
            {
                _logger.LogInformation($"No coffee found with name  {cofeeName}");
            }
            else
            {
                statusCode = HttpStatusCode.OK;
                coffeeDto = coffee.ToDto();
            }

            _logger.LogInformation($"Service-GetCoffeeByName-Executing GetCoffeeByName completed at {DateTime.UtcNow}");

            return (statusCode, coffeeDto);
        }

        public async Task<HttpStatusCode> UpdateCoffee(string coffeeDisplayid, List<PatchDto> patchDtos)
        {
            var statusCode = HttpStatusCode.NoContent;

            coffeeDisplayid.CheckArgumentIsNull(nameof(coffeeDisplayid));

            _logger.LogInformation($"Service-UpdateCoffee-Executing UpdateCoffee started at {DateTime.UtcNow}");

            _logger.LogInformation($"Service-UpdateCoffee-Executing get the coffee to be patched {DateTime.UtcNow}");

            var coffeeFromDb = await _coffeeRepository.FindAsync(s => s.CoffeeDisplayId == coffeeDisplayid && s.IsActive).ConfigureAwait(false);

            if (coffeeFromDb == null)
            {
                _logger.LogInformation($"No Area found with coffeeDisplayid {coffeeDisplayid}");
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                _coffeeRepository.ApplyPatch(coffeeFromDb, patchDtos);
                await _coffeeRepository.SaveAllwithAudit().ConfigureAwait(false);
            }

            return statusCode;
        }

        private void CheckArguments()
        {
            _coffeeRepository.CheckArgumentIsNull(nameof(_coffeeRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
    }
}
