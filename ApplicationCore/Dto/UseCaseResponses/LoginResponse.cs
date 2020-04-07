using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class LoginResponse : ResponseMessage
    {
        public LoginResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
