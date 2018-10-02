using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Options;
using CoffeeLovers.Helpers;
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
        private readonly Mail _mail;
        private readonly MailHelper _mailHelper;

        public OwnerController(IOwnerService ownerService,
                               IOptionsSnapshot<ApiSettings> apiSettings,
                               ILogger<OwnerController> logger,
                               Mail mail,
                               MailHelper mailHelper)
        {
            _ownerService = ownerService;
            _ownerLogger = logger;
            _apiSettings = apiSettings.Value;
            _mail = mail;
            _mailHelper = mailHelper;
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
                using (_ownerLogger.BeginScope($"API-AddOwner-started {DateTime.UtcNow}"))
                {
                    var result = await _ownerService.RegisterOwner(addOwnerDto).ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(result.ownerId) && result.confirmationToken != Guid.Empty)
                    {
                        string confirmationLink = Url.Action("ConfirmEmail",
                                                             "Account",
                                                             new
                                                             {
                                                                 userid = result.ownerId,
                                                                 token = result.confirmationToken
                                                             },
                                                             protocol: HttpContext.Request.Scheme);

                        var message = _mailHelper.GetEmailMessage("AddOwner",
                                        new { FullName= result.fullName, UserName = result.ownerId, ConfirmationLink = confirmationLink, EmailId= result.ownerEmailId });

                        await _mail.SendMailAsync(message);
                    }

                    _ownerLogger.LogInformation($"API-AddOwner-completed {DateTime.UtcNow}");

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