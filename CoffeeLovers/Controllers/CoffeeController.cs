using CoffeeLovers.APIModels;
using CoffeeLovers.APIModels;
using CoffeeLovers.Common;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CoffeeController : ApiController
    {
        private readonly ICoffeeService _coffeeService;
        private readonly ILogger _cofeelogger;

        public CoffeeController(ICoffeeService coffeeService, ILogger<CoffeeController> logger)
        {
            _coffeeService = coffeeService;
            _cofeelogger = logger;
            CheckArguments();
        }

        /// <summary>
        /// Adds an coffee to database
        /// </summary>
        /// <param name="coffeeDto"></param> 
        /// <returns>Location of the added coffee</returns>
        /// <response code="200">Returns 201 if the coffee is added successfully</response>
        /// <response code="400">Returns Bad request if invalid data or some exception</response>       
        [HttpPost("AddCoffee")]
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

                    return StatusCode((int)result.statusCode, result.cofeeDto);
                }
            }
            catch (Exception ex)
            {
                _cofeelogger.LogError
                    (ex,
                     $"API-AddCoffee-Exception {DateTime.UtcNow}"
                   );

                return StatusCode((int)HttpStatusCode.BadRequest,
                    _apiSettings.IsSecuredEnvironment ? "An error occured while processing AddCoffee" : ex.StackTrace);
            }
        }

        private void CheckArguments()
        {
            _coffeeService.CheckArgumentIsNull(nameof(_coffeeService));
            _cofeelogger.CheckArgumentIsNull(nameof(_cofeelogger));
        }
    }

    
}