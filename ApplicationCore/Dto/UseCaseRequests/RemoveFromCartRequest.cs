using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class RemoveFromCartRequest : IRequest<RemoveFromCartResponse>
    {
        public int ProductId { get; set; }
    }
}
