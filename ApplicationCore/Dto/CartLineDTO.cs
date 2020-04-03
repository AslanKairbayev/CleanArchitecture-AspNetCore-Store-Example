using ApplicationCore.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTO
{
    public class CartLineDTO
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
