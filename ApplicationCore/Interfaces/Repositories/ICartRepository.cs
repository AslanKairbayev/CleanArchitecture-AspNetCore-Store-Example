using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<CartLine> Lines { get; }
        void AddItem(Product product, int quantity);
        void RemoveLine(Product product);
        void ComputeTotalValue();
        void Clear();
    }
}
