using Core.Dto.RepositoryResponses.CartRepository;
using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<CartLine> lineCollection =  new List<CartLine>();

        public virtual async Task<IEnumerable<CartLine>> Lines() => await Task.FromResult(lineCollection);                  

        public virtual async Task<AddItemResponse> AddItem(Product product, int quantity)
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

            return await Task.FromResult(new AddItemResponse(true));
        }

        public virtual async Task<RemoveLineResponse> RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);

            return await Task.FromResult(new RemoveLineResponse(true));
        }
        public virtual async Task<decimal> ComputeTotalValue() => await Task.FromResult(
            lineCollection.Sum(e => e.Product.Price * e.Quantity));

        public virtual async Task Clear()
        {
            lineCollection.Clear();
            await Task.CompletedTask;
        }
                    
    }
}
