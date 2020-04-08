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

namespace ApplicationCore.UseCases
{
    public sealed class GetProductsByParamUseCase : IGetProductsByParamUseCase
    {
        private readonly IProductRepository repository;

        public GetProductsByParamUseCase(IProductRepository repo)
        {
            repository = repo;
        }
        public bool Handle(GetProductsByParamRequest request, IOutputPort<GetProductsByParamResponse> outputPort)
        {
            var products = repository.GetProductsByPaginationAndCategory(request.Page, request.PageSize, request.Category);

            if (products.Count() != 0)
            {
                var productsDto = new List<ProductDto>();

                foreach (var p in products)
                {
                    productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price));
                }

                outputPort.Handle(new GetProductsByParamResponse(productsDto, true));

                return true;
            }

            outputPort.Handle(new GetProductsByParamResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
