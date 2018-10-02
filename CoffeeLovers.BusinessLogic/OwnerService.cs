using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Logging;
using CoffeeLovers.Common.Mapping;
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
        private readonly IDictionaryRepository<OwnerService> _dictionaryRepository;
        private readonly IAppLogger<OwnerService> _logger;
        private readonly ISecurityService _securityService;
        private readonly IOwnerConfirmationRepository _ownerConfirmationRepository;

        public OwnerService(IOwnerRepository ownerRepository,
                            IDictionaryRepository<OwnerService> dictionaryRepository,
                            IAppLogger<OwnerService> logger,
                            ISecurityService securityService,
                            IOwnerConfirmationRepository ownerConfirmationRepository)
        {
            _ownerRepository = ownerRepository;
            _dictionaryRepository = dictionaryRepository;
            _logger = logger;
            _securityService = securityService;
            _ownerConfirmationRepository = ownerConfirmationRepository;
            CheckArguments();
        }

        public async Task<(HttpStatusCode statusCode, string ownerId, Guid confirmationToken, string ownerEmailId, string fullName)> RegisterOwner(AddOwnerDto addOwnerDto)
        {
            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner started at {DateTime.UtcNow}");

            addOwnerDto.CheckArgumentIsNull(nameof(addOwnerDto));

            var statusCode = HttpStatusCode.Created;
            string ownerId = string.Empty;
            string emailId = string.Empty;
            string fullName = string.Empty;
            Guid confirmationToken = Guid.Empty;

            var ownerSpec = new OwnerWithAreaSpecification(addOwnerDto.Email);

            var owner = (await _ownerRepository.ListAsync(ownerSpec).ConfigureAwait(false)).FirstOrDefault();
            if (owner != null)
            {
                _logger.LogInformation($"owner with email {addOwnerDto.Email} already exists!!!");
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Owner ownerEntity = await _ownerRepository.GetMaxOfPrimaryKey();
                string newOwnerDisplayId = ownerEntity.GetNextPrimaryKey();
                Dictionary<string, Guid> roles = _dictionaryRepository.RolesDictionary;

                Guid roleId = roles.Where(s => s.Key == addOwnerDto.RoleName).First().Value;

                var ownerDto = new SaveOwnerDto(roleId, newOwnerDisplayId)
                {
                    FirstName = addOwnerDto.FirstName,
                    LastName = addOwnerDto.LastName,
                    Email = addOwnerDto.Email
                };

                var ownerToAddToDb = ownerDto.ToEntity(true);
                ownerToAddToDb.Password = _securityService.GetSha256Hash(addOwnerDto.Password);
                await _ownerRepository.AddAsync(ownerToAddToDb).ConfigureAwait(false);

                //Add entry in ownerconfirmation table
                var ownerConfirmation = new OwnerConfirmation();
                ownerConfirmation.GenerateLinkAndToken(ownerToAddToDb.OwnerId);
                await _ownerConfirmationRepository.AddAsync(ownerConfirmation);
                await _ownerRepository.SaveAllwithAudit();

                ownerId = newOwnerDisplayId;
                confirmationToken = ownerConfirmation.confirmationToken;
                emailId = ownerToAddToDb.EmailId;
                fullName = ownerToAddToDb.FullName;
            }

            _logger.LogInformation($"Service-RegisterOwner-Executing RegisterOwner completed at {DateTime.UtcNow}");

            return (statusCode, ownerId, confirmationToken, emailId, fullName);
        }

        private void CheckArguments()
        {
            _ownerRepository.CheckArgumentIsNull(nameof(_ownerRepository));
            _dictionaryRepository.CheckArgumentIsNull(nameof(_dictionaryRepository));
            _logger.CheckArgumentIsNull(nameof(_logger));
            _ownerConfirmationRepository.CheckArgumentIsNull(nameof(_ownerConfirmationRepository));
        }
    }
}