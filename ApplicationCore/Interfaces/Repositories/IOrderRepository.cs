using ApplicationCore.Dto.RepositoryResponses.OrderRepository;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> UnshippedOrdersWithLines();
        Task<Order> GetOrderById(int orderId);
        Task<CreateOrderResponse> Create(Order order);
        Task<MarkShippedResponse> MarkShipped(int orderId);
    }
}
