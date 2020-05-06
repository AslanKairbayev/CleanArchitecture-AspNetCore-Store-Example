using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class CreateProductResponse : ResponseMessage
    {
        public int Id { get; }
        public CreateProductResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
