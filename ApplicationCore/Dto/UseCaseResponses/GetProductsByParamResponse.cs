using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetProductsByParamResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
