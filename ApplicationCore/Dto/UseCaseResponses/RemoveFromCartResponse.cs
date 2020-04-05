using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class RemoveFromCartResponse : ResponseMessage
    {
        public RemoveFromCartResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
