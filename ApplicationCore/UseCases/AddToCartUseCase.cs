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
        private IProductRepository prodRepository;

        private Cart cart;

        public AddToCartUseCase(IProductRepository prodRepo, Cart cartService)
        {
            prodRepository = prodRepo;
            cart = cartService;
        }

        public void Handle(int productId)
        {
            Product product = prodRepository.GetById(productId);
            
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
        }
    }
}
