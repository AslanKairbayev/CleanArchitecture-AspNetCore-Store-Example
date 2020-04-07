using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public int? ProductId { get; set; }

        public RemoveProductRequest(int? productId)
        {
            ProductId = productId;
        }
    }
}
