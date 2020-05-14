using Core.Dto.UseCaseResponses;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.UseCases
{
    public interface ICheckoutUseCase : IRequestHandler<CheckoutRequest, CheckoutResponse>
    {

    }
}
