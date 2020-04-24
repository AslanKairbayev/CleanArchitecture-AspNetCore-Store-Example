using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetProductsResponse : ResponseMessage
    {
        public IEnumerable<ProductDto> Products { get; }

        public GetProductsResponse(IEnumerable<ProductDto> products, bool success = false, string message = null) : base(success, message)
        {
            Products = products;
        }
    }    
}
