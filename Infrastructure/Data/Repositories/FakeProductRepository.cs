using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
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
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product> {
                    new Product
                    {
                        Id = 1,
                        Name = "Kayak",
                        Description = "А boat for one person",
                        CategoryId = 1,
                        Price = 275
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Lifejacket",
                        Description = "Protective and fashionaЫe",
                        CategoryId = 1,
                        Price = 48.95m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        CategoryId = 2,
                        Price = 19.50m
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Corner Flags",
                        Description = "Give your playing field а professional touch",
                        CategoryId = 2,
                        Price = 34.95m
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Stadium",
                        Description = "Flat-packed 35, 000-seat stadium",
                        CategoryId = 3,
                        Price = 79500
                    }                    
        }.AsQueryable<Product>();

        public Task<int> CountProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<CreateProductResponse> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteProductResponse> Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category)
        {
           return await Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public Task<UpdateProductResponse> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
