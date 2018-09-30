using CoffeeLovers.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeLovers.Controllers
{
    [ValidateModel]
    public abstract class ApiController : ControllerBase
    {
        protected ApiController()
        {
        }
    }
}