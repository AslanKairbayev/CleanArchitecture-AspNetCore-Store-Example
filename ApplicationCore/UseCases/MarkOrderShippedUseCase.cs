using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UseCases
{
    public sealed class MarkOrderShippedUseCase : IMarkOrderShippedUseCase
    {
        private readonly IOrderRepository repository;

        public MarkOrderShippedUseCase(IOrderRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(MarkOrderShippedRequest request, IOutputPort<MarkOrderShippedResponse> outputPort)
        {
            Order order = await repository.GetOrderById(request.OrderId);

            if (order != null)
            {
                var response = await repository.MarkShipped(order.Id);

                outputPort.Handle(response.Success ? new MarkOrderShippedResponse(true) : new MarkOrderShippedResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new MarkOrderShippedResponse(false, $"OrderId - {request.OrderId} not found"));

            return false;
        }
    }
}
