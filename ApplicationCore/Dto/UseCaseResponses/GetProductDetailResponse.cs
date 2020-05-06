using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetProductDetailResponse : ResponseMessage
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Category { get; }

        public GetProductDetailResponse(int id = 0, string name = null, string description = null, decimal price = 0, string category = null,
            bool success = false, string message = null)
            : base(success, message)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
