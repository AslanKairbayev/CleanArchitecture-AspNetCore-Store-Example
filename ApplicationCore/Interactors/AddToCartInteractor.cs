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
    public class AddToCartInteractor : IAddToCartUseCase
    {
        private IProductRepository prodRepository;

        private Cart cart;

        public AddToCartInteractor(IProductRepository prodRepo, Cart cartService)
        {
            prodRepository = prodRepo;
            cart = cartService;
        }

        public void Handle(int productId)
        {
            Product product = prodRepository.FindById(productId);
            
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
        }
    }
}
