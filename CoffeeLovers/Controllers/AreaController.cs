using CoffeeLovers.APIModels;
using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Options;
using CoffeeLovers.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
        private readonly ApiSettings _apiSettings;

        public AreaController(IAreaService areaService, ILogger<AreaController> logger, IOptionsSnapshot<ApiSettings> apiSettings)
        {
            _areaService = areaService;
            _arealogger = logger;
            _apiSettings = apiSettings.Value;
            CheckArguments();
        }

        /// <summary>
        /// Gets an Area by Name.
        /// </summary>
        /// <param name="name"></param>    
        /// <returns>A area whose name matches the one passed in the parameter</returns>
        /// <response code="200">Returns 200 when the response is success and the area that matches the name sent as route param </response>
        /// <response code="400">Bad request</response>  
        /// <response code="404">Not found if name passed does not match any item</response>  
        [HttpGet("GetAreaByName/{name}",Name =nameof(GetAreaByName))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAreaByName([FromRoute] string name)
        {
            try
            {
                using (_arealogger.BeginScope($"API-GetAreaByName-Inititating {DateTime.UtcNow}"))
                {
                    _arealogger.LogInformation(LoggingEvents.GetItem, "API-GetAreaByName-Getting item by name {name}", name);

                    var result = await _areaService.GetAreaByName(name).ConfigureAwait(false);                   

                    if (result.statusCode == HttpStatusCode.NotFound)
                    {
                        _arealogger.LogInformation(LoggingEvents.GetItemNotFound, "API-GetAreaByName-Item by name {name} not found", name);
                    }

                    _arealogger.LogInformation($"API-GetAreaByName-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.areaDto);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                    (ex,
                     $"API-GetAreaByName-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest, 
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetAreaByName" : ex.ToString());
            }
        }

        /// <summary>
        /// Gets an Area by Area Id.
        /// </summary>
        /// <param name="areaDisplayId">The id of the area we want to display</param>    
        /// <returns>A area whose name matches the one passed in the parameter</returns>
        /// <response code="200">Returns 200 when the response is success and the area that matches the name sent as route param </response>
        /// <response code="400">Bad request</response>  
        /// <response code="404">Not found if name passed does not match any item</response>  
        [HttpGet("GetAreaById/{areaDisplayId}", Name = nameof(GetAreaById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAreaById([FromRoute] string areaDisplayId)
        {
            try
            {
                using (_arealogger.BeginScope($"API-GetAreaById-Inititating {DateTime.UtcNow}"))
                {
                    _arealogger.LogInformation(LoggingEvents.GetItem, $"API-GetAreaById-Getting item by area displayid {areaDisplayId}");

                    var result = await _areaService.GetAreaByDisplayId(areaDisplayId).ConfigureAwait(false);

                    if (result.statusCode == HttpStatusCode.NotFound)
                    {
                        _arealogger.LogInformation(LoggingEvents.GetItemNotFound, $"API-GetAreaById-Item by area displayid  {areaDisplayId} not found");
                    }

                    _arealogger.LogInformation($"API-GetAreaById-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.areaDto);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                    (ex,
                     $"API-GetAreaById-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetAreaById" : ex.ToString());
            }
        }

        /// <summary>
        /// Gets all areas.
        /// </summary>
        /// <param name="includeAreaOwners"></param> 
        /// <returns>All areas present in the system</returns>
        /// <response code="200">Returns 200 and list of areas if resposnse is success</response>
        /// <response code="400">Bad request</response>         
        [HttpGet("GetAllAreas/{includeAreaOwners}", Name = nameof(GetAllAreas))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAllAreas(bool includeAreaOwners)
        {
            try
            {
                using (_arealogger.BeginScope($"API-GetAllAreas-Inititating {DateTime.UtcNow}"))
                {
                    var result = await _areaService.GetAllAreas(includeAreaOwners).ConfigureAwait(false);

                    _arealogger.LogInformation($"API-GetAllAreas-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.areaDtos);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                    (ex,
                     $"API-GetAllAreas-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetAllAreas" : ex.ToString());
            }
        }

        /// <summary>
        /// Adds an area to database
        /// </summary>
        /// <param name="areaDto"></param> 
        /// <returns>Location of the added area</returns>
        /// <response code="200">Returns 201 if the area is added successfully</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>       
        [HttpPost("AddArea", Name = nameof(AddArea))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddArea([FromBody] AreaDto areaDto)
        {
            try
            {
                using (_arealogger.BeginScope($"API-AddArea {DateTime.UtcNow}"))
                {
                    var result = await _areaService.CreateArea(areaDto).ConfigureAwait(false);

                    _arealogger.LogInformation($"API-AddArea {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.areaDisplayId);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                    (ex,
                     $"API-AddArea-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing AddArea" : ex.ToString());
            }
        }


        /// <summary>
        /// Updates an area in database
        /// </summary>
        /// <param name="areaDisplayId">The area id whose details have to be updated</param> 
        /// <param name="patchDtos">Properties that have to be updated</param> 
        /// <returns>Status code of the operation</returns>
        /// <response code="204">Returns 204 if the area is updated successfully</response>
        /// <response code="404">Returns 404 if the area is not found</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>       
        [HttpPatch("UpdateArea/{areaDisplayId}", Name = nameof(UpdateArea))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateArea(string areaDisplayId, [FromBody] List<PatchDto> patchDtos)
        {
            try
            {
                using (_arealogger.BeginScope($"API-UpdateArea {DateTime.UtcNow}"))
                {
                    var result = await _areaService.UpdateArea(areaDisplayId, patchDtos).ConfigureAwait(false);

                    _arealogger.LogInformation($"API-UpdateArea {DateTime.UtcNow}");

                    return StatusCode((int)result);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                  (ex,
                   $"API-UpdateArea-Exception {DateTime.UtcNow}"
                 );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing UpdateArea" : ex.ToString());
            }
        }

        /// <summary>
        /// Deleates an area in database
        /// </summary>
        /// <param name="areaDisplayId">The area id whose details have to be updated</param>      
        /// <returns>Status code of the operation</returns>
        /// <response code="204">Returns 204 if the area is deletion is successfull</response>
        /// <response code="404">Returns 404 if the area is not found</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>       
        [HttpDelete("DeleteArea/{areaDisplayId}", Name = nameof(DeleteArea))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteArea(string areaDisplayId)
        {
            try
            {
                using (_arealogger.BeginScope($"API-DeleteArea {DateTime.UtcNow}"))
                {
                    var result = await _areaService.DeleteArea(areaDisplayId).ConfigureAwait(false);

                    _arealogger.LogInformation($"API-DeleteArea {DateTime.UtcNow}");

                    return StatusCode((int)result);
                }
            }
            catch (Exception ex)
            {
                _arealogger.LogError
                  (ex,
                   $"API-DeleteArea-Exception {DateTime.UtcNow}"
                 );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing DeleteArea" : ex.ToString());
            }
        }

        private void CheckArguments()
        {
            _areaService.CheckArgumentIsNull(nameof(_areaService));
            _arealogger.CheckArgumentIsNull(nameof(_arealogger));
        }
    }

    
}