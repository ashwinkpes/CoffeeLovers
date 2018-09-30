using CoffeeLovers.Attributes;
using CoffeeLovers.Common.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace CoffeeLovers.Controllers
{
    [ValidateModel]
    public abstract class ApiController : ControllerBase
    {
        public ApiController()
        {
           
        }
      
    }
}
