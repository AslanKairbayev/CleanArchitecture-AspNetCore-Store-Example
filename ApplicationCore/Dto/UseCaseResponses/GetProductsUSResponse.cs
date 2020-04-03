using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetProductsUSResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }    
}
