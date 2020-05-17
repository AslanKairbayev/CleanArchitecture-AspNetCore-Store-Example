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
    public sealed class GetCategoriesUseCase : IGetCategoriesUseCase
    {
        private readonly IProductRepository repository;

        public GetCategoriesUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(GetCategoriesRequest request, IOutputPort<GetCategoriesResponse> outputPort)
        {
            var categories = await repository.GetCategories();
            outputPort.Handle(new GetCategoriesResponse(categories, true));
            return true;
        }
    }
}
