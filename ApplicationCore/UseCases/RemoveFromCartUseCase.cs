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

namespace ApplicationCore.UseCases
{
    public class RemoveFromCartUseCase : IRemoveFromCartUseCase
    {
        private IProductRepository productRepository;

        private ICartRepository cartRepository;

        public RemoveFromCartUseCase(IProductRepository repo, ICartRepository cart)
        {
            productRepository = repo;
            cartRepository = cart;
        }

        public bool Handle(RemoveFromCartRequest request, IOutputPort<RemoveFromCartResponse> outputPort)
        {
            Product product = productRepository.GetProductById(request.ProductId);

            if (product != null)
            {
                var response = cartRepository.RemoveLine(product);

                outputPort.Handle(response.Success ? new RemoveFromCartResponse(true) : new RemoveFromCartResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new RemoveFromCartResponse(false, $"Unknown ProductId - {request.ProductId}"));

            return false;
        }
    }
}
