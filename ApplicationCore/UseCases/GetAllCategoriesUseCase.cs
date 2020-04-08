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

namespace ApplicationCore.UseCases
{
    public sealed class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly ICategoryRepository repository;

        public GetAllCategoriesUseCase(ICategoryRepository repo)
        {
            repository = repo;
        }
        public bool Handle(GetAllCategoriesRequest request, IOutputPort<GetAllCategoriesResponse> outputPort)
        {
            var categories = repository.Categories;

            if (categories.Count() != 0)
            {
                var categoriesDto = new List<CategoryDto>();

                foreach (var c in categories)
                {
                    categoriesDto.Add(new CategoryDto(c.Id, c.Name, c.Description));
                }

                outputPort.Handle(new GetAllCategoriesResponse(categoriesDto, true));

                return true;
            }

            outputPort.Handle(new GetAllCategoriesResponse(null, false, "Operation failed"));

            return false;
        }
    }
}
