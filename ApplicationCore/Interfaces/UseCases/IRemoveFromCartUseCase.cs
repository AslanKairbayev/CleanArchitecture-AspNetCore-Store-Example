using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.UseCases
{
    public interface IRemoveFromCartUseCase : IRequestHandler<RemoveFromCartRequest, RemoveFromCartResponse>
    {

    }
}
