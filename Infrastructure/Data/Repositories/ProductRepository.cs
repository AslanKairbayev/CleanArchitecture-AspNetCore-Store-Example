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
   public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task<IEnumerable<Product>> ProductsWithCategories()
        { 
            return await context.Products.Include(i => i.Category).ToListAsync();
        } 

        public async Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category)
        {
            return await context.Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }
        public async Task<Product> GetProductById(int productId)
        {
            return await context.Products.FirstOrDefaultAsync(f => f.Id == productId);
        }

        public async Task<CreateProductResponse> Create(Product product)
        {
             context.Products.Add(product);

            await context.SaveChangesAsync();

            return new CreateProductResponse(product.Id, true);             
        }

        public async Task<UpdateProductResponse> Update(Product product)
        {
            Product dbEntry = await GetProductById(product.Id);

            dbEntry.Name = product.Name;
            dbEntry.Description = product.Description;
            dbEntry.Price = product.Price;
            dbEntry.CategoryId = product.CategoryId;

            await context.SaveChangesAsync();

            return new UpdateProductResponse(true);
        }

        public async Task<DeleteProductResponse> Delete(Product product)
        {
            context.Products.Remove(product);
            
            await context.SaveChangesAsync();

            return new DeleteProductResponse(true);
        }                    
    }
}
