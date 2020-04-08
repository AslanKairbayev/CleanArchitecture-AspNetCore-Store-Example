using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class GetProductsByParamRequest : IRequest<GetProductsByParamResponse>
    {        
        public int Page { get;}
        public int PageSize { get; }
        public string Category { get; }

        public GetProductsByParamRequest(int page, int pageSize, string category)
        {
            Page = page;
            PageSize = pageSize;
            Category = category;
        }
    }
}
