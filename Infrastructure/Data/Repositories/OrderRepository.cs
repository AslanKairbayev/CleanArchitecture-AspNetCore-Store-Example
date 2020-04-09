using ApplicationCore.Dto.RepositoryResponses.OrderRepository;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Order> UnshippedOrdersWithLines => context.Orders
            .Where(w => !w.Shipped)
            .Include(i => i.Lines)
            .ThenInclude(t => t.Product).ToList();

        public Order GetOrderById(int orderId)
        {
            return context.Orders.FirstOrDefault(f => f.Id == orderId);
        }

        public CreateOrderResponse Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();

            return new CreateOrderResponse(order.Id, true);
        }        

        public MarkShippedResponse MarkShipped(int orderId)
        {
            Order dbEntry = GetOrderById(orderId);

            dbEntry.Shipped = true;

            context.SaveChanges();

            return new MarkShippedResponse(true);
        }
    }
}
