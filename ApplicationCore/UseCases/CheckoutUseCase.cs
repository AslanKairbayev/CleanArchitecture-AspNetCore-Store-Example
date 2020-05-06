using Core.Dto.UseCaseResponses;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class CheckoutUseCase : ICheckoutUseCase
    {
        private readonly IOrderRepository orderRepository;

        private readonly ICartService cartService;

        public CheckoutUseCase(IOrderRepository repo, ICartService cart)
        {
            orderRepository = repo;
            cartService = cart;
        }

        public async Task<bool> Handle(CheckoutRequest request, IOutputPort<CheckoutResponse> outputPort)
        {
            var linesDto = cartService.Lines;

            if (!linesDto.Any())
            {
                outputPort.Handle(new CheckoutResponse(0, false, "Your Cart is Empty"));

                return false;
            }

            var lines = new List<CartLine>();

            foreach (var l in linesDto)
            {
                lines.Add(new CartLine() { Product = new Product() {
                    Id = l.ProductDto.Id,
                    Name = l.ProductDto.Name,
                    Description = l.ProductDto.Description,
                    Price = l.ProductDto.Price,
                    Category = l.ProductDto.Category
                }, 
                    Quantity = l.Quantity });
            }

            var response = await orderRepository.Create(new Order
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
                Lines = lines
            });

            outputPort.Handle(response.Success ? new CheckoutResponse(response.Id, true) : new CheckoutResponse(0, false, "Operation failed"));

            if (response.Success)
                await cartService.Clear();

            return response.Success;


        }
    }
}
