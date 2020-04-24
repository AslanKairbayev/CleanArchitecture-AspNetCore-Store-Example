using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Identity;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("Data:StoreExample:ConnectionString")));

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("Data:StoreIdentityExample:ConnectionString")));
            //services.AddIdentityCore<AppUser>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>();

            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddScoped<ICartRepository, CartRepository>();

            services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddTransient<ICategoryRepository, FakeCategoryRepository>();

            return services;
        }
    }
}
