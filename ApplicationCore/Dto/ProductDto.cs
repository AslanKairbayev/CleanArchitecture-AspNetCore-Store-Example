using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto
{
    public sealed class ProductDto
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public ProductDto(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
