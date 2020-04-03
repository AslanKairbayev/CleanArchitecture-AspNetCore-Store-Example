using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        void Update(Order order);
    }
}
