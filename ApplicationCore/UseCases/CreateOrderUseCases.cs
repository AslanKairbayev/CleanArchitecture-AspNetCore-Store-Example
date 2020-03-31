using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.UseCases
{
    public class CreateOrderUseCases : ICreateOrderUseCase
    {
        private IOrderRepository repository;

        private Cart cart;

        public CreateOrderUseCases(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public void Handle(CreateOrderRequest request)
        {
            if (cart.Lines.Count() != 0)
            {
                var entity = new Order
                {
                    Name = request.Name,
                    Line1 = request.Line1,
                    Line2 = request.Line2,
                    Line3 = request.Line3,
                    City = request.City,
                    State = request.State,
                    Zip = request.Zip,
                    Country = request.Country,
                    GiftWrap = request.GiftWrap,
                    Lines = cart.Lines.ToArray()
                };

                repository.Create(entity);
            }            
        }
    }
}
