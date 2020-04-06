using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UseCases
{
    public class MarkOrderShippedUseCase : IMarkOrderShippedUseCase
    {
        private IOrderRepository repository;

        public MarkOrderShippedUseCase(IOrderRepository repo)
        {
            repository = repo;
        }

        public bool Handle(MarkOrderShippedRequest request, IOutputPort<MarkOrderShippedResponse> outputPort)
        {
            Order order = repository.GetOrderById(request.OrderId);

            if (order != null)
            {
                order.Shipped = true;

                var response = repository.Update(order);

                outputPort.Handle(response.Success ? new MarkOrderShippedResponse(true) : new MarkOrderShippedResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new MarkOrderShippedResponse(false, $"Unknown OrderId - {request.OrderId}"));

            return false;
        }
    }
}
