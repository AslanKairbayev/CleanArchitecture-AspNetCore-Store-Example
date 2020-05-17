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

namespace Core.Interactors
{
    public sealed class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductRepository repository;

        public GetProductsUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(GetProductsRequest request, IOutputPort<GetProductsResponse> outputPort)
        {
            var products = await repository.GetProducts();
            var productsDto = new List<ProductDto>();
            foreach (var p in products)
            {
                productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Category));
            }
            outputPort.Handle(new GetProductsResponse(productsDto, true));
            return true;
        }
    }
}
