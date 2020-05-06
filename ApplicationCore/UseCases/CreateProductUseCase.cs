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
    public sealed class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository repository;

        public CreateProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(CreateProductRequest request, IOutputPort<CreateProductResponse> outputPort)
        {
            var response = await repository.Create(new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category
            });

            outputPort.Handle(response.Success ? new CreateProductResponse(response.Id, true) : new CreateProductResponse(0, false, "Operation failed"));

            return response.Success;
        }
    }
}
