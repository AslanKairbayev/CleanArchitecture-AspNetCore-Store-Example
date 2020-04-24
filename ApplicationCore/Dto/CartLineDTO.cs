using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public sealed class CartLineDto
    {
        public int Id { get; }
        public string ProductName { get; }
        public int Quantity { get; }

        public CartLineDto(int id, string productName, int quantity)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
