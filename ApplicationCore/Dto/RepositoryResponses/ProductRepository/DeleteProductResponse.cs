using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.ProductRepository
{
    public sealed class DeleteProductResponse : BaseRepositoryResponse
    {
        public DeleteProductResponse(bool success = false) : base(success)
        {

        }
    }
}
