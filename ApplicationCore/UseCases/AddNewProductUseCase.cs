using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UseCases
{
    public sealed class AddNewProductUseCase : IAddNewProductUseCase
    {
        private readonly IProductRepository repository;

        public AddNewProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public bool Handle(AddNewProductRequest request, IOutputPort<AddNewProductResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Description) && request.Price.HasValue && request.CategoryId.HasValue)
            {
                var response = repository.Create(new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = (decimal)request.Price,
                    CategoryId = (int)request.CategoryId
                }); 

                outputPort.Handle(response.Success ? new AddNewProductResponse(response.Id, true) : new AddNewProductResponse(0, false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new AddNewProductResponse(0, false, "Invalid request"));

            return false;
        }
    }
}
