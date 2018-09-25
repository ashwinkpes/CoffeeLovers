using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AreaController : ApiController
    {
        private readonly IAreaService _areaService;
        private readonly ILogger _arealogger;

        public AreaController(IAreaService areaService, ILogger<AreaController> logger)
        {
            _areaService = areaService;
            _arealogger = logger;
            CheckArguments();
        }

        [HttpGet("GetAreaByName/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAreaByName([FromRoute] string name)
        {
            try
            {
                using (_arealogger.BeginScope($"API-GetAllAreas-Inititating {DateTime.UtcNow}"))
                {
                    _arealogger.LogInformation(LoggingEvents.GetItem, "API-GetAllAreas-Getting item by name {name}", name);

                    var result = await _areaService.GetAreaByName(name).ConfigureAwait(false);                   

                    if (result.statusCode == HttpStatusCode.NotFound)
                    {
                        _arealogger.LogInformation(LoggingEvents.GetItemNotFound, "API-GetAllAreas-Item by name {name} not found", name);
                    }

                    _arealogger.LogInformation($"API-GetAllAreas-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.areaDto);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                    (ex,
                     $"API-GetAllAreas-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest, 
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetAreaByName" : ex.StackTrace);
            }
        }

        private void CheckArguments()
        {
            _areaService.CheckArgumentIsNull(nameof(_areaService));
            _arealogger.CheckArgumentIsNull(nameof(_arealogger));
        }
    }

    
}