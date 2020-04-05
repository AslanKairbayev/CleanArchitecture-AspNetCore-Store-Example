using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class CheckoutResponse : ResponseMessage
    {
        public int Id { get; set; }

        public CheckoutResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
