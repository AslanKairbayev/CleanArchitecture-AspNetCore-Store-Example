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
    public class AddToCartUseCase : IAddToCartUseCase
    {
        private IProductRepository productRepository;

        private ICartRepository cartRepository;

        public AddToCartUseCase(IProductRepository repo, ICartRepository cart)
        {
            productRepository = repo;
            cartRepository = cart;
        }

        public bool Handle(AddToCartRequest request, IOutputPort<AddToCartResponse> outputPort)
        {
            Product product = productRepository.GetProductById(request.ProductId);

            if (product != null)
            {
                var response = cartRepository.AddItem(product, 1);

                outputPort.Handle(response.Success ? new AddToCartResponse(true) : new AddToCartResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new AddToCartResponse(false, $"Unknown ProductId - {request.ProductId}"));

            return false;
        }
    }
}
