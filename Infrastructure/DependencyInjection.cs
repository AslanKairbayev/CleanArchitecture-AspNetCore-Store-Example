using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.FakeRepositories;
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
            string connection = configuration.GetConnectionString("StoreExample");
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            string identityConnection = configuration.GetConnectionString("StoreExampleIdentity");

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(identityConnection));

            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();


            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            //services.AddSingleton<IProductRepository, FakeProductRepository>();
            //services.AddSingleton<IOrderRepository, FakeOrderRepository>();

            return services;
        }
    }
}
