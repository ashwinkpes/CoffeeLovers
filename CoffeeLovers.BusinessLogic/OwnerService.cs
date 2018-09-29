﻿using CoffeeLovers.APIModels;
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
        private readonly IAppLogger<OwnerService> _logger;

        public OwnerService(IOwnerRepository ownerRepository, IAppLogger<OwnerService> logger)
        {
            _ownerRepository = ownerRepository;
            _logger = logger;
            CheckArguments();
        }

        public async Task<(HttpStatusCode statusCode, OwnerDto ownerDto)> RegisterOwner(AddEditOwnerDto addOwnerDto, bool isAdminUser)
        {
            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner started at {DateTime.UtcNow}");

            addOwnerDto.CheckArgumentIsNull(nameof(addOwnerDto));

            var statusCode = HttpStatusCode.Created;
            OwnerDto ownerToStrore = default(OwnerDto);

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

                if (!isAdminUser)
                {
                  
                }

                ownerToStrore = new OwnerDto(newCoffeeDisplayId);
                ownerToStrore.Email = addOwnerDto.Email;
                ownerToStrore.FirstName = addOwnerDto.FirstName;
                ownerToStrore.LastName = addOwnerDto.LastName;                     
            }

            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner completed at {DateTime.UtcNow}");

            return (statusCode, ownerToStrore);
        }

        private void CheckArguments()
        {
            _ownerRepository.CheckArgumentIsNull(nameof(_ownerRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
    }
}