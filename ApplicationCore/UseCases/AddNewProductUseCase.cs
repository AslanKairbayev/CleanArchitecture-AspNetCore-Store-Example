using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class AddNewProductUseCase : IAddNewProductUseCase
    {
        private readonly IProductRepository repository;

        public AddNewProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(AddNewProductRequest request, IOutputPort<AddNewProductResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Description) && request.Price.HasValue && !string.IsNullOrEmpty(request.Category))
            {
                var response =  await repository.Create(new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = (decimal)request.Price,
                    Category = request.Category
                }); 

                outputPort.Handle(response.Success ? new AddNewProductResponse(response.Id, true) : new AddNewProductResponse(0, false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new AddNewProductResponse(0, false, "Invalid request"));

            return false;
        }
    }
}
