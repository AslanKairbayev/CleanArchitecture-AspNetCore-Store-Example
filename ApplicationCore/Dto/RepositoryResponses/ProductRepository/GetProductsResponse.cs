using ApplicationCore.Dto.Repository;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.ProductRepository
{
    public class GetProductsResponse : BaseRepositoryResponse
    {
        public IEnumerable<Product> Products { get; }

        public GetProductsResponse( IEnumerable<Product> products, bool success = false) : base(success)
        {
            Products = products; 
        }
    }
}
