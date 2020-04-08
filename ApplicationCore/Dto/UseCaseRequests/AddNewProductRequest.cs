using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class AddNewProductRequest : IRequest<AddNewProductResponse>
    {
        public string Name { get; }
        public string Description { get; }
        public decimal? Price { get; }
        public int? CategoryId { get; }

        public AddNewProductRequest(string name, string description, decimal? price, int? categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
