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
using CoffeeLovers.APIModels.Coffee;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CoffeeController : ApiController
    {
        private readonly ICoffeeService _coffeeService;
        private readonly ILogger _cofeelogger;
        private readonly ApiSettings _apiSettings;

        public CoffeeController(ICoffeeService coffeeService, ILogger<CoffeeController> logger, IOptionsSnapshot<ApiSettings> apiSettings)
        {
            _coffeeService = coffeeService;
            _cofeelogger = logger;
            _apiSettings = apiSettings.Value;
            CheckArguments();
        }

        /// <summary>
        /// Adds an coffee to database
        /// </summary>
        /// <param name="coffeeDto"></param> 
        /// <returns>Location of the added coffee</returns>
        /// <response code="200">Returns 201 if the coffee is added successfully</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>       
        [HttpPost("AddCoffee", Name = nameof(AddCoffee))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddCoffee([FromBody] AddCoffeeDto coffeeDto)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-AddCoffee {DateTime.UtcNow}"))
                {
                    var result = await _coffeeService.CreateCoffee(coffeeDto).ConfigureAwait(false);

                    _cofeelogger.LogInformation($"API-AddCoffee {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.coffeeId);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                    (ex,
                     $"API-AddCoffee-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing AddCoffee" : ex.ToString());
            }
        }


        /// <summary>
        /// Gets all coffees.
        /// </summary>
        /// <param name="includeCofeeAreas"></param> 
        /// <returns>All coffees present in the system</returns>
        /// <response code="200">Returns 200 and list of coffees if resposnse is success</response>
        /// <response code="400">Bad request</response>         
        [HttpGet("GetAllCoffees/{includeCofeeAreas}", Name = nameof(GetAllCoffees))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAllCoffees(bool includeCofeeAreas)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-GetAllCoffees-Inititating {DateTime.UtcNow}"))
                {
                    var result = await _coffeeService.GetAllCoffees(includeCofeeAreas).ConfigureAwait(false);

                    _cofeelogger.LogInformation($"API-GetAllCoffees-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.coffeeDtos);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                    (ex,
                     $"API-GetAllCoffees-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetAllCoffees" : ex.ToString());
            }
        }

        /// <summary>
        /// Gets an coffee by ID
        /// </summary>
        /// <param name="coffeeId">Enter coffee ID</param>
        /// <returns>Coffe that matches a given id</returns>
        /// <response code="200">Returns 200 when the coffee with specified id is found</response>
        /// <response code="404">Returns 404 when the coffee with specified id is not found</response>
        /// <response code="400">Returns 400 in case of bad request</response>
        [HttpGet("GetCoffeeById/{coffeeId}", Name = nameof(GetCoffeeById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetCoffeeById(string coffeeId)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-GetCoffeeById-Inititating {DateTime.UtcNow}"))
                {
                    _cofeelogger.LogInformation(LoggingEvents.GetItem, $"API-GetCoffeeById-Getting item by coffeeId {coffeeId}");

                    var result = await _coffeeService.GetCoffeeByDisplayId(coffeeId).ConfigureAwait(false);

                    if (result.statusCode == HttpStatusCode.NotFound)
                    {
                        _cofeelogger.LogInformation(LoggingEvents.GetItemNotFound, $"API-GetCoffeeById-Item by coffeeId  {coffeeId} not found");
                    }

                    _cofeelogger.LogInformation($"API-GetCoffeeById-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.coffeeDto);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                    (ex,
                     $"API-GetCoffeeById-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetCoffeeById" : ex.ToString());
            }
        }

        /// <summary>
        /// Gets an coffee by name
        /// </summary>
        /// <param name="coffeeName">Enter coffee name</param>
        /// <returns>Coffe that matches a given coffee name</returns>
        /// <response code="200">Returns 200 when the coffee with specified name is found</response>
        /// <response code="404">Returns 404 when the coffee with specified name is not found</response>
        /// <response code="400">Returns 400 in case of bad request</response>
        [HttpGet("GetCoffeeByName/{coffeeName}", Name = nameof(GetCoffeeByName))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetCoffeeByName(string coffeeName)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-GetCoffeeByName-Inititating {DateTime.UtcNow}"))
                {
                    _cofeelogger.LogInformation(LoggingEvents.GetItem, $"API-GetCoffeeByName-Getting item by name {coffeeName}");

                    var result = await _coffeeService.GetCoffeeByName(coffeeName).ConfigureAwait(false);

                    if (result.statusCode == HttpStatusCode.NotFound)
                    {
                        _cofeelogger.LogInformation(LoggingEvents.GetItemNotFound, $"API-GetCoffeeByName-Item by name  {coffeeName} not found");
                    }

                    _cofeelogger.LogInformation($"API-GetCoffeeByName-Completed {DateTime.UtcNow}");

                    return StatusCode((int)result.statusCode, result.coffeeDto);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                    (ex,
                     $"API-GetCoffeeByName-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing GetCoffeeByName" : ex.ToString());
            }
        }

        /// <summary>
        /// Deletes an coffee in database
        /// </summary>
        /// <param name="coffeeDisplayId">The coffee id whose details have to be updated</param>      
        /// <returns>Status code of the operation</returns>
        /// <response code="204">Returns 204 if the coffee deletion is successfull</response>
        /// <response code="404">Returns 404 if the coffee is not found</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>    
        [HttpDelete("DeleteCoffee/{coffeeDisplayId}", Name = nameof(DeleteCoffee))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCoffee(string coffeeDisplayId)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-DeleteCoffee {DateTime.UtcNow}"))
                {
                    var result = await _coffeeService.DeleteCoffee(coffeeDisplayId).ConfigureAwait(false);

                    _cofeelogger.LogInformation($"API-DeleteCoffee {DateTime.UtcNow}");

                    return StatusCode((int)result);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                  (ex,
                   $"API-DeleteCoffee-Exception {DateTime.UtcNow}"
                 );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing DeleteCoffee" : ex.ToString());
            }
        }

        /// <summary>
        /// Updates an coffee in database
        /// </summary>
        /// <param name="coffeeDisplayId">The coffee id whose details have to be updated</param> 
        /// <param name="patchDtos">Properties that have to be updated</param> 
        /// <returns>Status code of the operation</returns>
        /// <response code="204">Returns 204 if the coffee is updated successfully</response>
        /// <response code="404">Returns 404 if the coffee is not found</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>     
        [HttpPatch("UpdateCoffee/{coffeeDisplayId}", Name = nameof(UpdateCoffee))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateCoffee(string coffeeDisplayId, [FromBody] List<PatchDto> patchDtos)
        {
            try
            {
                using (_cofeelogger.BeginScope($"API-UpdateCoffee {DateTime.UtcNow}"))
                {
                    var result = await _coffeeService.UpdateCoffee(coffeeDisplayId, patchDtos).ConfigureAwait(false);

                    _cofeelogger.LogInformation($"API-UpdateCoffee {DateTime.UtcNow}");

                    return StatusCode((int)result);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                  (ex,
                   $"API-UpdateCoffee-Exception {DateTime.UtcNow}"
                 );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing UpdateCoffee" : ex.ToString());
            }
        }

        private void CheckArguments()
        {
            _coffeeService.CheckArgumentIsNull(nameof(_coffeeService));
            _cofeelogger.CheckArgumentIsNull(nameof(_cofeelogger));
        }
    }

    
}