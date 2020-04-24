using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class CheckoutResponse : ResponseMessage
    {
        public int Id { get; }

        public CheckoutResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
