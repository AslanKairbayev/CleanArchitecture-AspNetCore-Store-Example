using ApplicationCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "А boat for one person",
                        CategoryId = 1,
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionaЫe",
                        CategoryId = 1,
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        CategoryId = 2,
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field а professional touch",
                        CategoryId = 2,
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35, 000-seat stadium",
                        CategoryId = 2,
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Сар",
                        Description = "Improve brain efficiency Ьу 75i",
                        CategoryId = 3,
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent а disadvantage",
                        CategoryId = 3,
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "А fun game for the family",
                        CategoryId = 3,
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        CategoryId = 3,
                        Price = 1200
                    }
                    );
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Watersports",
                        Description = "Make a splash"
                    },
                    new Category
                    {
                        Name = "Soccer",
                        Description = "The world's favorite game"
                    },
                    new Category
                    {
                        Name = "Chess",
                        Description = "Game for smart people"
                    }
                    );
            }
            context.SaveChanges();
        }
    }
}
