﻿using CoffeeLovers.BusinessLogic;
using CoffeeLovers.IBusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterBusinessServices
    {
        internal static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<ISecurityService, SecurityService>();
        }
    }
}