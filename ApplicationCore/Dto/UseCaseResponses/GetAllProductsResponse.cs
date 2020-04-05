using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetAllProductsResponse : ResponseMessage
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public GetAllProductsResponse(IEnumerable<ProductDto> products, bool success = false, string message = null) : base(success, message)
        {
            Products = products;
        }
    }    
}
