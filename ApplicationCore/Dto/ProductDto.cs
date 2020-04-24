using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public sealed class ProductDto
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Category { get; }

        public ProductDto(int id, string name, string description, decimal price, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
