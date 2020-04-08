using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class MarkOrderShippedRequest : IRequest<MarkOrderShippedResponse>
    {
        public int OrderId { get; }

        public MarkOrderShippedRequest(int orderId)
        {
            OrderId = orderId;
        }
    }
}
