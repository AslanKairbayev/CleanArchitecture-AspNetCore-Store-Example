using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
