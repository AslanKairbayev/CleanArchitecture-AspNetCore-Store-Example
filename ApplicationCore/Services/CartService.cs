using Core.Dto;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CartService : ICartService
    {
        protected List<CartLineDto> lineCollection = new List<CartLineDto>();

        public virtual IEnumerable<CartLineDto> Lines => lineCollection;

        public virtual async Task AddItem(ProductDto product, int quantity)
        {
            CartLineDto line = lineCollection
            .Where(p => p.ProductDto.Id == product.Id)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLineDto(product, quantity));
            }
            else
            {
                line.Quantity += quantity;
            }

            await Task.CompletedTask;
        }

        public virtual async Task RemoveLine(ProductDto product)
        {
            lineCollection.RemoveAll(l => l.ProductDto.Id == product.Id);

            await Task.CompletedTask;
        }
        public virtual async Task<decimal> ComputeTotalValue() => await Task.FromResult(
            lineCollection.Sum(e => e.ProductDto.Price * e.Quantity));

        public virtual async Task Clear()
        {
            lineCollection.Clear();

            await Task.CompletedTask;
        }
    }

}
