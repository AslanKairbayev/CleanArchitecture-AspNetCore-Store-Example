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
    public sealed class CreateNewProductUseCase : ICreateNewProductUseCase
    {
        private readonly IProductRepository repository;

        public CreateNewProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(CreateProductRequest request)
        {
            await repository.Create(new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category
            });

            return true;
        }
    }
}
