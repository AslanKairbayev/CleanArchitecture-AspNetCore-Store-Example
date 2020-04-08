using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto
{
    public sealed class CartLineDto
    {
        public int Id { get; }
        public ProductDto ProductDto { get; }
        public int Quantity { get; }

        public CartLineDto(int id, ProductDto productDto, int quantity)
        {
            Id = id;
            ProductDto = productDto;
            Quantity = quantity;
        }
    }
}
