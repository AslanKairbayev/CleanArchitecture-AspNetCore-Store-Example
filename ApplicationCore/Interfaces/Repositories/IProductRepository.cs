using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ProductsWithCategories();
        Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category);
        Task<Product> GetProductById(int productId);
        Task<CreateProductResponse> Create(Product product);
        Task<UpdateProductResponse> Update(Product product);
        Task<DeleteProductResponse> Delete(Product product);
    }
}
