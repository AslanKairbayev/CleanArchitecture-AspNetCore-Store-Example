using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetProductsByParamResponse : ResponseMessage
    {
        public IEnumerable<ProductDto> Products { get; }
        public int Page { get; } = 0;
        public int PageSize { get; } = 0;
        public string Category { get; } = null;
        public int TotalItems { get; } = 0;

        public GetProductsByParamResponse(IEnumerable<ProductDto> products, int page = 0, int pageSize = 0,  int totalItems = 0, string category = null, 
            bool success = false, string message = null) : base(success, message)
        {
            Products = products;
            TotalItems = totalItems;
            Page = page;
            PageSize = pageSize;
            Category = category;
        }
    }
}
