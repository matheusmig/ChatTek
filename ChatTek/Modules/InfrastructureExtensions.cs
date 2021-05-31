﻿using Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ChatTek.Modules
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IIdentityService, IdentityService>();

            return serviceCollection;
        }
    }
}
