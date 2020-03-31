using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.UseCases
{
    public interface IGetAllProductsUseCase : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
    }
}
