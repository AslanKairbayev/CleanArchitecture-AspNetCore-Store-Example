using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class AddNewProductResponse : ResponseMessage
    {
        public int Id { get; }
        public AddNewProductResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = Id;
        }
    }
}
