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
    public sealed class AddToCartUseCase : IAddToCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly ICartService _cartService;

        public AddToCartUseCase(IProductRepository repo, ICartService cartService)
        {
            productRepository = repo;
            _cartService = cartService;
        }

        public async Task<bool> Handle(AddToCartRequest request)
        {
            Product product = await productRepository.GetProductById(request.ProductId);

            if (product == null)
            {
                return false;
            }

            await _cartService.AddItem(new ProductDto(product.Id, product.Name, product.Description, product.Price, product.Category), 1);

            return true;
        }
    }
}
