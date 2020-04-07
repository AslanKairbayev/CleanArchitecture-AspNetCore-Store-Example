using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UseCases
{
    public class RemoveProductUseCase : IRemoveProductUseCase
    {
        private IProductRepository repository;

        public RemoveProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public bool Handle(RemoveProductRequest request, IOutputPort<RemoveProductResponse> outputPort)
        {
            if (request.ProductId.HasValue)
            {
                var product = repository.GetProductById((int)request.ProductId);

                if (product != null)
                {
                    var response = repository.Delete(product.Id);

                    outputPort.Handle(response.Success ? new RemoveProductResponse(true) : new RemoveProductResponse(false, "Operation failed"));

                    return response.Success;
                }                
            }

            outputPort.Handle(new RemoveProductResponse(false, "Invalid request"));

            return false;
        }
    }
}
