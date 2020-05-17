using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
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
            var order = await repository.GetOrderById(request.OrderId);

            if (order != null)
            {
                await repository.MarkShipped(request.OrderId);

                outputPort.Handle(new MarkOrderShippedResponse(true));
                return true;
            }            

            outputPort.Handle(new MarkOrderShippedResponse(false, $"OrderId - {request.OrderId} was not found"));
            return false;
        }
    }
}
