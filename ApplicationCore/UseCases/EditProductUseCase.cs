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
    public sealed class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository repository;

        public EditProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(EditProductRequest request, IOutputPort<EditProductResponse> outputPort)
        {          
            if (request.Id.HasValue && !string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Description) && request.Price.HasValue && !string.IsNullOrEmpty(request.Category))
            {
                var product = await repository.GetProductById((int)request.Id);

                if (product != null)
                {
                    var response = await repository.Update(new Product
                    {
                        Id = (int)request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        Price = (decimal)request.Price,
                        Category = request.Category
                    });

                    outputPort.Handle(response.Success ? new EditProductResponse(true) : new EditProductResponse(false, "Operation failed"));

                    return response.Success;
                }                
            }

            outputPort.Handle(new EditProductResponse(false, "Invalid request"));

            return false;
        }
    }
}
