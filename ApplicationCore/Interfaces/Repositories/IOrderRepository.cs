using Core.Dto.RepositoryResponses.OrderRepository;
using Core.Dto.UseCaseResponses;
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
        Task<CreateOrderResponse> Create(Order order);
        Task<MarkShippedResponse> MarkShipped(int orderId);
    }
}
