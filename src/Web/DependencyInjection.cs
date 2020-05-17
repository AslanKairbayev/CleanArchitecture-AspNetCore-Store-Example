using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Presenters;
using Web.Services;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services.AddScoped<GetProductsByParamPresenter>();
            services.AddScoped<GetProductsPresenter>();
            services.AddScoped<GetProductDetailPresenter>();
            services.AddScoped<GetCategoriesPresenter>();
            services.AddScoped<CreateProductPresenter>();
            services.AddScoped<UpdateProductDetailPresenter>();
            services.AddScoped<RemoveProductPresenter>();

            services.AddScoped<GetCartPresenter>();
            services.AddScoped<AddToCartPresenter>();
            services.AddScoped<RemoveFromCartPresenter>();

            services.AddScoped<GetUnshippedOrdersPresenter>();
            services.AddScoped<CheckoutPresenter>();
            services.AddScoped<MarkOrderShippedPresenter>();

            services.AddScoped<LoginPresenter>();

            services.AddScoped<ICartService, SessionCartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
