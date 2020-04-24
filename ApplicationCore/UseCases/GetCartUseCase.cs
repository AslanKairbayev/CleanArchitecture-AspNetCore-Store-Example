using Core.Dto;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public class GetCartUseCase : IGetCartUseCase
    {
        private readonly ICartRepository cartRepository;

        public GetCartUseCase(ICartRepository cart)
        {
            cartRepository = cart;
        }
        public async Task<bool> Handle(GetCartRequest request, IOutputPort<GetCartResponse> outputPort)
        {
            var lines = await cartRepository.Lines();

            if (lines.Any())
            {
                var linesDto = new List<CartLineDto>();

                foreach (var c in lines)
                {
                    linesDto.Add(new CartLineDto(c.Id, c.Product.Name, c.Quantity));
                }

                outputPort.Handle(new GetCartResponse(linesDto, true));

                return true;
            }

            outputPort.Handle(new GetCartResponse(null, false, "Cart is Empty"));

            return false;

        }
    }
}
