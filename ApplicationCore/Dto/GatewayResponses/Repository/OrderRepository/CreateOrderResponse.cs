using Core.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RepositoryResponses.OrderRepository
{
    public sealed class CreateOrderResponse : BaseGatewayResponse
    {
        public int Id { get; }
        public CreateOrderResponse(int id, bool success = false) : base(success)
        {
            Id = id;
        }
    }
}
