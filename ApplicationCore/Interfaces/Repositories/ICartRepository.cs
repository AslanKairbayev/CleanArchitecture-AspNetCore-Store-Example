using ApplicationCore.Dto.RepositoryResponses.CartRepository;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartLine>> Lines();
        Task<AddItemResponse> AddItem(Product product, int quantity);
        Task<RemoveLineResponse> RemoveLine(Product product);
        Task<decimal> ComputeTotalValue();
        Task Clear();
    }
}
