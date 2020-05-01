using Core.Dto;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetCartResponse : ResponseMessage
    {
        public IEnumerable<CartLineDto> Lines { get; }
        public decimal TotalValue { get; }

        public GetCartResponse(IEnumerable<CartLineDto> cart, decimal totalValue, bool success = false, string message = null) : base(success, message)
        {
            Lines = cart;
            TotalValue = totalValue;
        }
    }
}
