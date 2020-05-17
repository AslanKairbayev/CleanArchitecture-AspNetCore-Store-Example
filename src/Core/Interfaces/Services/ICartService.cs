using Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICartService
    {
        IEnumerable<CartLineDto> Lines {get;}
        Task AddItem(ProductDto product, int quantity);
        Task RemoveLine(ProductDto product);
        Task<decimal> ComputeTotalValue();
        Task Clear();
    }
}
