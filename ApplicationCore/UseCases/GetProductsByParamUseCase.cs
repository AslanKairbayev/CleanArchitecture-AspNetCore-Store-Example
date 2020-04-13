using ApplicationCore.Dto;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
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
    public sealed class GetProductsByParamUseCase : IGetProductsByParamUseCase
    {
        private readonly IProductRepository repository;

        public GetProductsByParamUseCase(IProductRepository repo)
        {
            repository = repo;
        }
        public async Task<bool> Handle(GetProductsByParamRequest request, IOutputPort<GetProductsByParamResponse> outputPort)
        {
            var products = await repository.GetProductsByPaginationAndCategory(request.Page, request.PageSize, request.Category);

            if (products.Any())
            {
                var productsDto = new List<ProductDto>();

                foreach (var p in products)
                {
                    productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price, null));
                }

                outputPort.Handle(new GetProductsByParamResponse(productsDto, true));

                return true;
            }

            outputPort.Handle(new GetProductsByParamResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
