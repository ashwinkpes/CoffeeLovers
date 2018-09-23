using Microsoft.AspNetCore.Mvc;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AreaController : ControllerBase
    {
        public AreaController()
        {
           
        }
    }
}