using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseRequests
{
    public class EditProductRequest : IRequest<EditProductResponse>
    {
        public int? Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal? Price { get; }
        public int? CategoryId { get; }

        public EditProductRequest(int? id, string name, string description, decimal? price, int? categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
