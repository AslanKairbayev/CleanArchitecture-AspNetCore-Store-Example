using Core.Dto.RepositoryResponses.ProductRepository;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<string>> GetCategories();
        Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category);
        Task<int> CountProductsByCategory(string category);
        Task<Product> GetProductById(int productId);
        Task<Dto.RepositoryResponses.ProductRepository.CreateProductGatewayResponse> Create(Product product);
        Task<UpdateProductResponse> Update(Product product);
        Task<DeleteProductResponse> Delete(Product product);
    }
}
