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
using System.Threading.Tasks;

namespace ApplicationCore.UseCases
{
    public sealed class CheckoutUseCase : ICheckoutUseCase
    {
        private readonly IOrderRepository orderRepository;

        private readonly ICartRepository cartRepository;

        public CheckoutUseCase(IOrderRepository repo, ICartRepository cart)
        {
            orderRepository = repo;
            cartRepository = cart;
        }

        public async Task<bool> Handle(CheckoutRequest request, IOutputPort<CheckoutResponse> outputPort)
        {
            var lines = await cartRepository.Lines();

            if (!lines.Any())
            {
                outputPort.Handle(new CheckoutResponse(0, false, "Cart is Empty"));

                return false;
            }

            if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Line1) && !string.IsNullOrEmpty(request.City)
                && !string.IsNullOrEmpty(request.State) && !string.IsNullOrEmpty(request.Country))
            {
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
                    Lines = lines.ToList()
                });

                outputPort.Handle(response.Success ? new CheckoutResponse(response.Id, true) : new CheckoutResponse(0, false, "Operation failed"));

                if (response.Success)
                await cartRepository.Clear();

                return response.Success;
            }
            else
            {
                outputPort.Handle(new CheckoutResponse(0, false, "Invalid request"));

                return false;
            }            
        }
    }
}
