using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts { get; }
        IEnumerable<Product> GetProductsByPaginationAndCategory(int page, int pageSize, string category);
        Product GetProductById(int productId);
        CreateProductResponse Create(Product product);
        UpdateProductResponse Update(Product product);
        DeleteProductResponse Delete(int productId);
    }
}
