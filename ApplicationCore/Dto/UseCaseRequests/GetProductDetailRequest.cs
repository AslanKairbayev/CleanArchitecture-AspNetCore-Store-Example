using Core.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class GetProductDetailRequest : IRequest<GetProductDetailResponse>
    {
        public int Id { get; }

        public GetProductDetailRequest(int id)
        {
            Id = id;
        }
    }
}
