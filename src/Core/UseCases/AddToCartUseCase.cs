using Core.Dto;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class AddToCartUseCase : IAddToCartUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ICartService _cartService;

        public AddToCartUseCase(IProductRepository repo, ICartService cartService)
        {
            productRepository = repo;
            _cartService = cartService;
        }

        public async Task<bool> Handle(AddToCartRequest request, IOutputPort<AddToCartResponse> outputPort)
        {
            var product = await productRepository.GetProductById(request.ProductId);
            if (product != null)
            {
                await _cartService.AddItem(new ProductDto(product.Id, product.Name, product.Description, product.Price, product.Category), 1);
                outputPort.Handle(new AddToCartResponse(true));
                return true;
            }
            outputPort.Handle(new AddToCartResponse(false, $"ProductId - {request.ProductId} was not found"));
            return false;
        }
    }
}
