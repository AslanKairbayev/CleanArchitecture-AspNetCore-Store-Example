using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetProductsByPaginationAndCategory(int page, int pageSize, string category);
        Product GetProductById(int productId);        
        void Update(Product product);
    }
}
