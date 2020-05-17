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
using Core.Interfaces.Services;
using Core.Services;

namespace Core.UseCases
{
    public class GetCartUseCase : IGetCartUseCase
    {
        private readonly ICartService  _cartService;

        public GetCartUseCase(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<bool> Handle(GetCartRequest request, IOutputPort<GetCartResponse> outputPort)
        {
            var linesDto = _cartService.Lines;

            if (!linesDto.Any())
            {
                outputPort.Handle(new GetCartResponse(null, 0, false, "Your Cart is Empty"));
                return false;
            }

            var totalValue = await _cartService.ComputeTotalValue();

            outputPort.Handle(new GetCartResponse(linesDto, totalValue, true));
            return true;
        }
    }
}
