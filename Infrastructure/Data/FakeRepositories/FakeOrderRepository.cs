using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.FakeRepositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        private readonly List<Order> Orders = new List<Order>();

        private int id = 0;

        public async Task<IEnumerable<Order>> UnshippedOrdersWithLines()
        {
            return await Task.FromResult(Orders
            .Where(w => !w.Shipped));
        }

        public async Task Create(Order order)
        {
            order.Id = ++id;

            Orders.Add(order);

            await Task.CompletedTask;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await Task.FromResult(Orders.FirstOrDefault(f => f.Id == orderId));
        }

        public async Task MarkShipped(int orderId)
        {
            foreach (var o in Orders)
            {
                if (o.Id == orderId)
                {
                    o.Shipped = true;
                }
            }

            await Task.CompletedTask;
        }
        
    }
}
