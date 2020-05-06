using Core.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RepositoryResponses.ProductRepository
{
    public sealed class CreateProductGatewayResponse : BaseGatewayResponse
    {
        public int Id { get; }
        public CreateProductGatewayResponse(int id, bool success = false) : base(success)
        {
            Id = id;
        }
    }
}
