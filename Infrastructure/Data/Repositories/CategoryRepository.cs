using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext ctx) => context = ctx;

        public async Task<IEnumerable<Category>> Categories()
        { 
            return await context.Categories.ToListAsync();
        }
        
    }
}
