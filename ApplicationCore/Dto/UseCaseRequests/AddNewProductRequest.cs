using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests
{
    public class AddNewProductRequest : IRequest<AddNewProductResponse>
    {
        public string Name { get; }
        public string Description { get; }
        public decimal? Price { get; }
        public string Category { get; }

        public AddNewProductRequest(string name, string description, decimal? price, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
