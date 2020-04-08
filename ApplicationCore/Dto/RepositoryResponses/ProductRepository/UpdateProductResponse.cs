using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.ProductRepository
{
    public sealed class UpdateProductResponse : BaseRepositoryResponse
    {
        public UpdateProductResponse(bool success = false) : base(success)
        {
            
        }
    }
}
