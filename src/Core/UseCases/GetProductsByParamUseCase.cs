using Core.Dto;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
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

            var productsDto = new List<ProductDto>();
            
            foreach (var p in products)
            {
                productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price, null));
            }
            
            var totalItems = await repository.CountProductsByCategory(request.Category);
            
            outputPort.Handle(new GetProductsByParamResponse(productsDto, request.Page, request.PageSize, totalItems, request.Category, true));
            
            return true;          
        }
    }
}
