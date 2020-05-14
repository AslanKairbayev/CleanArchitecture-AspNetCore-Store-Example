using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class MarkOrderShippedRequest
    {
        public int OrderId { get; }

        public MarkOrderShippedRequest(int orderId)
        {
            OrderId = orderId;
        }
    }
}
