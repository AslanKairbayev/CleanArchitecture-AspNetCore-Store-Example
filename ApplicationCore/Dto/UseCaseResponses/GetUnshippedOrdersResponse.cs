using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{

    public class GetUnshippedOrdersResponse : ResponseMessage
    {
        public IEnumerable<OrderDto> Orders { get; }

        public GetUnshippedOrdersResponse(IEnumerable<OrderDto> orders, bool success = false, string message = null) : base(success, message)
        {
            Orders = orders;
        }
    }
}
