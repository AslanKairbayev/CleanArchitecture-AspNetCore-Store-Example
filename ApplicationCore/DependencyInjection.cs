using Core.Interfaces.UseCases;
using Core.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGetProductsByParamUseCase, GetProductsByParamUseCase>();

            return services;
        }
    }
}
