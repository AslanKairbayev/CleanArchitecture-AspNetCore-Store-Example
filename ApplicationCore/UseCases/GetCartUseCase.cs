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
            var lines = _cartService.Lines;

            if (lines.Any())
            {
                var totalValue = await _cartService.ComputeTotalValue();

                outputPort.Handle(new GetCartResponse(lines, totalValue, true));

                return true;
            }
            else
            {
                outputPort.Handle(new GetCartResponse(lines, 0, false, "Cart is Empty"));

                return false;
            }
}
    }
}
