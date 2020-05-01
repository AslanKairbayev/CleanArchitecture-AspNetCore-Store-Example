using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class CartLineDto
    {
        public ProductDto ProductDto { get; set; }
        public int Quantity { get; set; }

        public CartLineDto(ProductDto product, int quantity)
        {
            ProductDto = product;
            Quantity = quantity;
        }
    }
}
