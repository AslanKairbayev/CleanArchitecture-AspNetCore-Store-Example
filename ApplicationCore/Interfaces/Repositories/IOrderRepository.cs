using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> UnshippedOrdersWithLines();
        Task<Order> GetOrderById(int orderId);
        Task Create(Order order);
        Task MarkShipped(int orderId);
    }
}
