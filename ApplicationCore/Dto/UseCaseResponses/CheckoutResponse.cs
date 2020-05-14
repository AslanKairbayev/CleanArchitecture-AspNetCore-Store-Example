using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class CheckoutResponse : ResponseMessage
    {
        public CheckoutResponse(bool success = false, string message = null) : base(success, message)
        {
           
        }
    }
}
