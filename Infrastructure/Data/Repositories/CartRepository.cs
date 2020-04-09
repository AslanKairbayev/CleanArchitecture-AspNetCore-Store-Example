using ApplicationCore.Dto.RepositoryResponses.CartRepository;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public virtual IEnumerable<CartLine> Lines =>
            lineCollection;

        public virtual AddItemResponse AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

            return new AddItemResponse(true);
        }

        public virtual RemoveLineResponse RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);

            return new RemoveLineResponse(true);
        }
        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() =>
            lineCollection.Clear();               
    }
}
