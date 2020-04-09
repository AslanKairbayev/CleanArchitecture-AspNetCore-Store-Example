using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Product> ProductsWithCategories => context.Products.Include(i => i.Category).ToList();

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

            var changes = context.SaveChanges();

            if (changes != 0)
            {
                return new CreateProductResponse(product.Id, true);
            }

            return new CreateProductResponse(0);             
        }

        public UpdateProductResponse Update(Product product)
        {
            Product dbEntry = GetProductById(product.Id);

            dbEntry.Name = product.Name;
            dbEntry.Description = product.Description;
            dbEntry.Price = product.Price;
            dbEntry.CategoryId = product.CategoryId;

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
