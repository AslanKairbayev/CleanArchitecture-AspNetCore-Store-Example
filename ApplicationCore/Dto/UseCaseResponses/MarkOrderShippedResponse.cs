using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class MarkOrderShippedResponse : ResponseMessage
    {
        public MarkOrderShippedResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
