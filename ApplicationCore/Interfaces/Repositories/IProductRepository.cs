using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        GetProductsByPaginationAndCategoryResponse GetProductsByPaginationAndCategory(int page, int pageSize, string category);
        void Update(Product product);
    }
}
