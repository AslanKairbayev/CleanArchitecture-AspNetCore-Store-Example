using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.OrderRepository
{
    public class CreateOrderResponse : BaseRepositoryResponse
    {
        public int Id { get; set; }
        public CreateOrderResponse(int id, bool success = false) : base(success)
        {
            Id = id;
        }
    }
}
