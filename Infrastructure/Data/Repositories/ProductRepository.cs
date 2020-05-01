using Core.Dto.RepositoryResponses.ProductRepository;
using Core.Entities;
using Core.Interfaces.Repositories;
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

        public async Task<IEnumerable<Product>> GetProducts()
        { 
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetCategories()
        {
            return await Task.FromResult(context.Products
                .Select(s => s.Category)
                .Distinct()
                .OrderBy(o => o));
        }

        public async Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category)
        {
            return await context.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public async Task<int> CountProductsByCategory(string category)
        {
            return await context.Products
                .Where(w => category == null || w.Category == category)
                .CountAsync();
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
            dbEntry.Category = product.Category;

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
