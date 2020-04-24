using Core.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RepositoryResponses.OrderRepository
{
    public sealed class MarkShippedResponse : BaseGatewayResponse
    {
        public MarkShippedResponse(bool success = false) : base(success)
        {
            
        }
    }
}
