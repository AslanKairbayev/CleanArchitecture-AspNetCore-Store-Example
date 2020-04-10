using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.DTO;
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
    public sealed class RemoveFromCartUseCase : IRemoveFromCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly ICartRepository cartRepository;

        public RemoveFromCartUseCase(IProductRepository repo, ICartRepository cart)
        {
            productRepository = repo;
            cartRepository = cart;
        }

        public async Task<bool> Handle(RemoveFromCartRequest request, IOutputPort<RemoveFromCartResponse> outputPort)
        {
            Product product = await productRepository.GetProductById(request.ProductId);

            if (product != null)
            {
                var response = await cartRepository.RemoveLine(product);

                outputPort.Handle(response.Success ? new RemoveFromCartResponse(true) : new RemoveFromCartResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new RemoveFromCartResponse(false, $"ProductId - {request.ProductId} not found"));

            return false;
        }
    }
}
