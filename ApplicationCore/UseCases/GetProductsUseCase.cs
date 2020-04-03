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

namespace ApplicationCore.Interactors
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private IProductRepository repository;

        public GetProductsUseCase(IProductRepository repo)
        {
            repository = repo;
        }
        public bool Handle(GetProductsRequest request, IOutputPort<GetProductsResponse> outputPort)
        {
            var products = repository.GetAll.ToList();

            var productsDto = new List<ProductDto>();

            foreach (var p in products)
            {
                productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price));
            }

            outputPort.Handle(new GetProductsResponse { Products = productsDto });

            return true;
        }
    }
}
