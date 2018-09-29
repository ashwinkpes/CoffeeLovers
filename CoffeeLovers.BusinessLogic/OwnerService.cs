using CoffeeLovers.APIModels;
using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Logging;
using CoffeeLovers.Common.Mapping;
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
    public class OwnerService : IOwnerService
    {       
        private readonly IOwnerRepository _ownerRepository;
        private readonly IDictionaryRepsository<OwnerService> _dictionaryRepsository;
        private readonly IAppLogger<OwnerService> _logger;

        public OwnerService(IOwnerRepository ownerRepository, IDictionaryRepsository<OwnerService> dictionaryRepsository, IAppLogger<OwnerService> logger)
        {
            _ownerRepository = ownerRepository;
            _dictionaryRepsository = dictionaryRepsository;
            _logger = logger;
            CheckArguments();
        }

        public async Task<(HttpStatusCode statusCode, string ownerId)> RegisterOwner(AddEditOwnerDto addOwnerDto)
        {
            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner started at {DateTime.UtcNow}");

            addOwnerDto.CheckArgumentIsNull(nameof(addOwnerDto));

            var statusCode = HttpStatusCode.Created;
            string ownerId = string.Empty;

            var ownerSpec = new OwnerWithAreaSpecification(addOwnerDto.Email, false);

            var owner = (await _ownerRepository.ListAsync(ownerSpec).ConfigureAwait(false)).FirstOrDefault();
            if (owner != null)
            {
                _logger.LogInformation($"owner with email {addOwnerDto.Email} already exists!!!");
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Owner ownerEntity = await _ownerRepository.GetMaxOfprimaryKey();
                string newCoffeeDisplayId = ownerEntity.GetNextPrimaryKey();
                Dictionary<string,Guid> roles =  _dictionaryRepsository.RolesDictionary;

            }

            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner completed at {DateTime.UtcNow}");

            return (statusCode, ownerId);
        }

        private void CheckArguments()
        {
            _ownerRepository.CheckArgumentIsNull(nameof(_ownerRepository));
            _dictionaryRepsository.CheckArgumentIsNull(nameof(_dictionaryRepsository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
    }
}
