using Core.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RepositoryResponses.ProductRepository
{
    public sealed class DeleteProductResponse : BaseGatewayResponse
    {
        public DeleteProductResponse(bool success = false) : base(success)
        {

        }
    }
}
