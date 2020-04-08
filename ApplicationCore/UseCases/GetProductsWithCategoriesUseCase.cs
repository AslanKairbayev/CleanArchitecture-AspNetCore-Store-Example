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

namespace ApplicationCore.Interactors
{
    public sealed class GetProductsWithCategoriesUseCase : IGetProductsWithCategoriesUseCase
    {
        private readonly IProductRepository repository;

        public GetProductsWithCategoriesUseCase(IProductRepository repo)
        {
            repository = repo;
        }
        public bool Handle(GetProductsWithCategoriesRequest request, IOutputPort<GetProductsWithCategoriesResponse> outputPort)
        {
            var products = repository.ProductsWithCategories;

            if (products.Count() != 0)
            {
                var productsDto = new List<ProductDto>();

                foreach (var p in products)
                {
                    productsDto.Add(new ProductDto(p.Id, p.Name, p.Description, p.Price, new CategoryDto(p.Category.Id, p.Category.Name, p.Category.Description)));
                }

                outputPort.Handle(new GetProductsWithCategoriesResponse(productsDto, true));

                return true;
            }

            outputPort.Handle(new GetProductsWithCategoriesResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
