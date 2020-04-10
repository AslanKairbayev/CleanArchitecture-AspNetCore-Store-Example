using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UseCases
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
                var response = await repository.Delete(product);

                outputPort.Handle(response.Success ? new RemoveProductResponse(true) : new RemoveProductResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new RemoveProductResponse(false, $"ProductId - {request.ProductId} not found"));

            return false;
        }
    }
}
