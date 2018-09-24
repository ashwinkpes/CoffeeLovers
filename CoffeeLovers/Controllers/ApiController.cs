using CoffeeLovers.Attributes;
using CoffeeLovers.Common.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoffeeLovers.Controllers
{
    [ValidateModel]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ApiSettings _apiSettings;

        public ApiController()
        {
            
        }

        public ApiController(IOptionsSnapshot<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

    }
}
