using ApplicationCore.Dto.UseCaseResponses;
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
    public class CheckoutUseCase : ICheckoutUseCase
    {
        private IOrderRepository orderRepository;

        private ICartRepository cartRepository;

        public CheckoutUseCase(IOrderRepository repo, ICartRepository cart)
        {
            orderRepository = repo;
            cartRepository = cart;
        }

        public bool Handle(CheckoutRequest request, IOutputPort<CheckoutResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Line1) && !string.IsNullOrEmpty(request.City) 
                && !string.IsNullOrEmpty(request.State) && !string.IsNullOrEmpty(request.Country) && cartRepository.Lines.Count() != 0)
            {
                var response = orderRepository.Create(new Order
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
                    Lines = cartRepository.Lines.ToArray()
                });

                outputPort.Handle(response.Success ? new CheckoutResponse(response.Id, true) : null);

                return response.Success;
            }

            return false;
        }
    }
}
