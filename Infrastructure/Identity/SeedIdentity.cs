using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity
{
    public static class SeedIdentity
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<AppUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<AppUser>>();
            AppUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new AppUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
