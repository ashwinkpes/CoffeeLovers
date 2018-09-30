using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Options;
using CoffeeLovers.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ApiController
    {
        private readonly IOwnerService _ownerService;
        private readonly ILogger _ownerLogger;
        private readonly ApiSettings _apiSettings;

        public OwnerController(IOwnerService ownerService, IOptionsSnapshot<ApiSettings> apiSettings,
            ILogger<OwnerController> logger)
        {
            _ownerService = ownerService;
            _ownerLogger = logger;
            _apiSettings = apiSettings.Value;
            CheckArguments();
        }

        /// <summary>
        /// Adds an owner to database
        /// </summary>
        /// <param name="addOwnerDto"></param>
        /// <returns>Location of the added owner</returns>
        /// <response code="200">Returns 201 if the area is added successfully</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>
        [HttpPost("AddOwner", Name = nameof(AddOwner))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddOwner([FromBody] AddOwnerDto addOwnerDto)
        {
            try
            {
                using (_ownerLogger.BeginScope($"API-AddOwner {DateTime.UtcNow}"))
                {
                    var result = await _ownerService.RegisterOwner(addOwnerDto).ConfigureAwait(false);

                    _ownerLogger.LogInformation($"API-AddArea {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.ownerId);
                }
            }
            catch (Exception ex)
            {
                _ownerLogger.LogError
                    (ex,
                     $"API-AddOwner-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing AddOwner" : ex.ToString());
            }
        }

        private void CheckArguments()
        {
            _ownerService.CheckArgumentIsNull(nameof(_ownerService));
            _ownerLogger.CheckArgumentIsNull(nameof(_ownerLogger));
        }
    }
}