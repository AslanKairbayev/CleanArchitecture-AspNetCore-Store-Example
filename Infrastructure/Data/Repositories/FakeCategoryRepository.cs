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
    public class FakeCategoryRepository : ICategoryRepository
    {
        public IQueryable<Category> AllCategories => new List<Category> {
                    new Category
                    {
                        Id = 1,
                        Name = "Watersport"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Soccer"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Chess"
                    }
        }.AsQueryable<Category>();

        public async Task<IEnumerable<Category>> Categories()
        {
            return await AllCategories.ToListAsync();
        }
    }
}
