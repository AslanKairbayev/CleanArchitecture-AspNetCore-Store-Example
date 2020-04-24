using Core.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RepositoryResponses.CartRepository
{
    public sealed class AddItemResponse : BaseGatewayResponse
    {
        public AddItemResponse(bool success = false) : base(success)
        {
            
        }
    }
}
