using ApplicationCore.Dto.RepositoryResponses.OrderRepository;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUnshippedOrders { get; }
        Order GetOrderById(int orderId);
        CreateOrderResponse Create(Order order);
        UpdateOrderResponse Update(Order order);
    }
}
