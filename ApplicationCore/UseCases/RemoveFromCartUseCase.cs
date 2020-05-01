using Core.Dto;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class RemoveFromCartUseCase : IRemoveFromCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly ICartService _cartService;

        public RemoveFromCartUseCase(IProductRepository repo, ICartService cartService)
        {
            productRepository = repo;
            _cartService = cartService;
        }

        public async Task<bool> Handle(RemoveFromCartRequest request, IOutputPort<RemoveFromCartResponse> outputPort)
        {
            Product product = await productRepository.GetProductById(request.ProductId);

            if (product != null)
            {
                await _cartService.RemoveLine(new ProductDto(product.Id, product.Name, product.Description, product.Price, null));

                outputPort.Handle(new RemoveFromCartResponse(true));

                return true;
            }

            outputPort.Handle(new RemoveFromCartResponse(false, $"ProductId - {request.ProductId} not found"));

            return false;
        }
    }
}
