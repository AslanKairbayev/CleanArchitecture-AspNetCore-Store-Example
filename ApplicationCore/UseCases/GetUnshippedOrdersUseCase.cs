using ApplicationCore.Dto;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.UseCases
{
    public sealed class GetUnshippedOrdersUseCase : IGetUnshippedOrdersUseCase
    {
        private readonly IOrderRepository repository;

        public GetUnshippedOrdersUseCase(IOrderRepository repo)
        {
            repository = repo;
        }

        public bool Handle(GetUnshippedOrdersRequest request, IOutputPort<GetUnshippedOrdersResponse> outputPort)
        {
            var orders = repository.UnshippedOrders;

            if (orders.Count() != 0)
            {
                var ordersDto = new List<OrderDto>();                

                foreach (var o in orders)
                {
                    var linesDto = new List<CartLineDto>();

                    foreach (var l in o.Lines)
                    {
                        linesDto.Add(new CartLineDto(l.Id, new ProductDto(l.Product.Id, l.Product.Name, l.Product.Description, l.Product.Price, null), l.Quantity));
                    }

                    ordersDto.Add(new OrderDto(o.Id, o.Name, o.Line1, o.Line2, o.Line3, o.City, o.State, o.Country, o.Zip, o.GiftWrap, o.Shipped, linesDto));
                }

                outputPort.Handle(new GetUnshippedOrdersResponse(ordersDto, true));

                return true;
            }

            outputPort.Handle(new GetUnshippedOrdersResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
