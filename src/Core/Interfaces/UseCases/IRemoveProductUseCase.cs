using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.UseCases
{
    public interface IRemoveProductUseCase : IRequestHandler<RemoveProductRequest>
    {
    }
}
