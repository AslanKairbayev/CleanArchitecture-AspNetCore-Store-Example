using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto
{
    public class CartLineDto
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
        public int Quantity { get; set; }

        public CartLineDto(int id, ProductDto productDto, int quantity)
        {
            Id = id;
            ProductDto = productDto;
            Quantity = quantity;
        }
    }
}
