using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetAllCategoriesUseCaseUnitTests
    {
        [Fact]
        public async void Can_Get_All_Categories()
        {
            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository
              .Setup(m => m.Categories())
              .Returns(GetCategories());

            var useCase = new GetCategoriesUseCase(mockCategoryRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetCategoriesResponse>()));

            var response = await useCase.Handle(new GetCategoriesRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Get_All_Categories_When_Categories_Are_Empty()
        {
            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository
              .Setup(m => m.Categories())
              .Returns(GetEmptyCategories());

            var useCase = new GetCategoriesUseCase(mockCategoryRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetCategoriesResponse>()));

            var response = await useCase.Handle(new GetCategoriesRequest(), mockOutputPort.Object);

            Assert.False(response);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = new List<Category>();

            categories.Add(new Category());

            return await Task.FromResult(categories);
        }

        public async Task<IEnumerable<Category>> GetEmptyCategories()
        {
            var categories = new List<Category>();

            return await Task.FromResult(categories);
        }

    }
}
