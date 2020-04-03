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
    class RemoveFromCartUseCasescs : IRemoveFromCartUseCase
    {
        private IProductRepository prodRepository;

        private Cart cart;

        public RemoveFromCartUseCasescs(IProductRepository prodRepo, Cart cartService)
        {
            prodRepository = prodRepo;
            cart = cartService;
        }

        public void Handle(int productId)
        {
            Product product = prodRepository.GetById(productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
        }
    }
}
