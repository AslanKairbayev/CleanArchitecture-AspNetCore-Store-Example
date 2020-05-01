using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using Core.Services;
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
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IGetProductsByParamUseCase, GetProductsByParamUseCase>();
            services.AddScoped<IGetCategoriesUseCase, GetCategoriesUseCase>();

            //services.AddSingleton<ICartService, CartService>();
            services.AddScoped<IGetCartUseCase, GetCartUseCase>();
            services.AddScoped<IAddToCartUseCase, AddToCartUseCase>();
            services.AddScoped<IRemoveFromCartUseCase, RemoveFromCartUseCase>();

            return services;
        }
    }
}
