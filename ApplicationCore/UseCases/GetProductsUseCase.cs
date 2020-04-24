using ApplicationCore.Dto;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interactors
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

            if (products.Any())
            {
                var productsDto = new List<ProductDto>();

                foreach (var p in products)
                {
                    productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price, new CategoryDto(p.Category.Id, p.Category.Name, p.Category.Description)));
                }

                outputPort.Handle(new GetProductsResponse(productsDto, true));

                return true;
            }

            outputPort.Handle(new GetProductsResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
