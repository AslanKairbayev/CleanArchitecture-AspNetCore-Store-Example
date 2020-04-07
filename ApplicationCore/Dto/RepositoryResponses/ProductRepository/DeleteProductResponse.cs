using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.ProductRepository
{
    public class DeleteProductResponse : BaseRepositoryResponse
    {
        public DeleteProductResponse(bool success = false) : base(success)
        {

        }
    }
}
