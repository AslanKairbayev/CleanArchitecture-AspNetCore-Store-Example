using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.UseCases
{
    public interface ICheckoutUseCase : IRequestHandler<CheckoutRequest, CheckoutResponse>
    {

    }
}
