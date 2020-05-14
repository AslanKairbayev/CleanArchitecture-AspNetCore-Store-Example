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

        public async Task<bool> Handle(MarkOrderShippedRequest request)
        {
            Order order = await repository.GetOrderById(request.OrderId);

            if (order == null)            
            {                
                return false;
            }

            await repository.MarkShipped(request.OrderId);

            return true;
        }
    }
}
