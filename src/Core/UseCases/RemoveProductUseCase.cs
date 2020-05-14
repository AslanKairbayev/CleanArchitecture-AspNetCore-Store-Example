using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class RemoveProductUseCase : IRemoveProductUseCase
    {
        private IProductRepository repository;

        public RemoveProductUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(RemoveProductRequest request)
        {
            var product = await repository.GetProductById(request.ProductId);

            if (product == null)
            {
                return false;
            }
            
            await repository.Delete(product);

            return true;
        }
    }
}
