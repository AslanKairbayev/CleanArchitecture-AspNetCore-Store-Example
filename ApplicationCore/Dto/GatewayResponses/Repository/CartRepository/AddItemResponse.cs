using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.CartRepository
{
    public sealed class AddItemResponse : BaseGatewayResponse
    {
        public AddItemResponse(bool success = false) : base(success)
        {
            
        }
    }
}
