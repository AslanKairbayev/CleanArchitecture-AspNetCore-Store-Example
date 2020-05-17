using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class RemoveProductUseCase : IRemoveProductUseCase
    {
        private IProductRepository repository;

        public RemoveProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(RemoveProductRequest request, IOutputPort<RemoveProductResponse> outputPort)
        {
            var product = await repository.GetProductById(request.ProductId);

            if (product != null)
            {
                await repository.Delete(product);

                outputPort.Handle(new RemoveProductResponse(true));
                return true;
            }

            outputPort.Handle(new RemoveProductResponse(false, $"ProductId - {request.ProductId} was not found"));
            return false;
        }
    }
}
