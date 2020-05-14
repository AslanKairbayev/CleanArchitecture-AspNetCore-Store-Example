using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class GetProductsByParamRequest : IRequest<GetProductsByParamResponse>
    {
        public int Page { get; }
        public int PageSize { get; }
        public string Category { get; }

        public GetProductsByParamRequest(int page = 1, string category = null, int pageSize = 4)
        {
            Page = page;
            PageSize = pageSize;
            Category = category;
        }
    }
}
