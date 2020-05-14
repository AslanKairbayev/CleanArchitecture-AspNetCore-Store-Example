using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class AddToCartRequest
    {
        public int ProductId { get; }

        public AddToCartRequest(int productId)
        {
            ProductId = productId;
        }
    }
}
