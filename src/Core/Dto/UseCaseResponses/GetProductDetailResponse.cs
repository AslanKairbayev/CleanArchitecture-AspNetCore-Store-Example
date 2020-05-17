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

        public GetProductDetailResponse(int id, string name, string description, decimal price, string category,
            bool success = false, string message = null) : base(success, message)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public GetProductDetailResponse(bool success = false, string message = null) : base(success, message) { }        
    }
}
