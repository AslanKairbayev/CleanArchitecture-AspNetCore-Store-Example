using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.OrderRepository
{
    public class UpdateOrderResponse : BaseRepositoryResponse
    {
        public UpdateOrderResponse(int id, bool success = false) : base(success)
        {
            
        }
    }
}
