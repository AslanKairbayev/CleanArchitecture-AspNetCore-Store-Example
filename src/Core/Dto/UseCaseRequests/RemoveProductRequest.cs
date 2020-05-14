using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class RemoveProductRequest
    {
        public int ProductId { get; }

        public RemoveProductRequest(int productId)
        {
            ProductId = productId;
        }
    }
}
