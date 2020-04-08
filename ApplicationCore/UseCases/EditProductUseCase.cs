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
    public sealed class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository repository;

        public EditProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public bool Handle(EditProductRequest request, IOutputPort<EditProductResponse> outputPort)
        {          
            if (request.Id.HasValue && !string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Description) && request.Price.HasValue && request.CategoryId.HasValue)
            {
                var product = repository.GetProductById((int)request.Id);

                if (product != null)
                {
                    var response = repository.Update(new Product
                    {
                        Id = (int)request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        Price = (decimal)request.Price,
                        CategoryId = (int)request.CategoryId
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
