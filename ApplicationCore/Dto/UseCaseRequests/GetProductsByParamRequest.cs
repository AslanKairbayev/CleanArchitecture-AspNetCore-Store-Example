using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class GetProductsByParamRequest : IRequest
    {        
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Category { get; set; }

        public GetProductsByParamRequest(int page, int pageSize, string category)
        {
            Page = page;
            PageSize = pageSize;
            Category = category;
        }
    }
}
