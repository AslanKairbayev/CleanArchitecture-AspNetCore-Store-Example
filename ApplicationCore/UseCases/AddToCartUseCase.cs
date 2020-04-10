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
    public sealed class AddToCartUseCase : IAddToCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly ICartRepository cartRepository;

        public AddToCartUseCase(IProductRepository repo, ICartRepository cart)
        {
            productRepository = repo;
            cartRepository = cart;
        }

        public async Task<bool> Handle(AddToCartRequest request, IOutputPort<AddToCartResponse> outputPort)
        {
            Product product = await productRepository.GetProductById(request.ProductId);

            if (product != null)
            {
                var response = await cartRepository.AddItem(product, 1);

                outputPort.Handle(response.Success ? new AddToCartResponse(true) : new AddToCartResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new AddToCartResponse(false, $"ProductId - {request.ProductId} not found"));

            return false;
        }
    }
}
