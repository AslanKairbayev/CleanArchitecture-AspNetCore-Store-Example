using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class RemoveFromCartRequest : IRequest<RemoveFromCartResponse>
    {
        public int ProductId { get; }

        public RemoveFromCartRequest(int productId)
        {
            ProductId = productId;
        }
    }
}
