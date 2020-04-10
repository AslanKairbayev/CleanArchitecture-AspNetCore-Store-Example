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
using System.Threading.Tasks;

namespace ApplicationCore.UseCases
{
    public sealed class GetCategoriesUseCase : IGetCategoriesUseCase
    {
        private readonly ICategoryRepository repository;

        public GetCategoriesUseCase(ICategoryRepository repo)
        {
            repository = repo;
        }
        public async Task<bool> Handle(GetCategoriesRequest request, IOutputPort<GetCategoriesResponse> outputPort)
        {
            var categories = await repository.Categories();

            if (categories.Count() != 0)
            {
                var categoriesDto = new List<CategoryDto>();

                foreach (var c in categories)
                {
                    categoriesDto.Add(new CategoryDto(c.Id, c.Name, c.Description));
                }

                outputPort.Handle(new GetCategoriesResponse(categoriesDto, true));

                return true;
            }

            outputPort.Handle(new GetCategoriesResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
