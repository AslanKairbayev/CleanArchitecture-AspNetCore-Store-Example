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
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
