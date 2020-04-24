using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetCartResponse : ResponseMessage
    {
        public IEnumerable<CartLineDto> Lines { get; }

        public GetCartResponse(IEnumerable<CartLineDto> cart, bool success = false, string message = null) : base(success, message)
        {
            Lines = cart;
        }
    }
}
