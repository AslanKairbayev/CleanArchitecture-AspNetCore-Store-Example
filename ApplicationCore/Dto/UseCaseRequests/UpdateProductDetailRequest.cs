using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class UpdateProductDetailRequest : IRequest<UpdateProductDetailResponse>
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Category { get; }

        public UpdateProductDetailRequest(int id, string name, string description, decimal price, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
