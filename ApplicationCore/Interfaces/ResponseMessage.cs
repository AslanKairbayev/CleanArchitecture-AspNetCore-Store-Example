using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public abstract class ResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        protected ResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
