using ApplicationCore.Dto.RepositoryResponses.CartRepository;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<CartLine> Lines { get; }
        AddItemResponse AddItem(Product product, int quantity);
        RemoveLineResponse RemoveLine(Product product);
        void ComputeTotalValue();
        void Clear();
    }
}
