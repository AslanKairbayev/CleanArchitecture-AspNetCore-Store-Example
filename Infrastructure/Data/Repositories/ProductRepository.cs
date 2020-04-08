using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
   public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Product> Products => context.Products.ToList();

        public IEnumerable<Product> GetProductsByPaginationAndCategory(int page, int pageSize, string category)
        {
            return context.Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public Product GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(f => f.Id == productId);
        }

        public CreateProductResponse Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

            return new CreateProductResponse(product.Id, true);
        }

        public UpdateProductResponse Update(Product product)
        {
            Product dbEntry = GetProductById(product.Id);

            if (dbEntry != null)
            {
                dbEntry.Name = product.Name;
                dbEntry.Description = product.Description;
                dbEntry.Price = product.Price;
                dbEntry.CategoryId = product.CategoryId;
            }
            context.SaveChanges();

            return new UpdateProductResponse(true);
        }

        public DeleteProductResponse Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();

            return new DeleteProductResponse(true);
        }                    
    }
}
