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
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetAllCategoriesUseCaseUnitTests
    {
        [Fact]
        public void Can_Get_All_Categories()
        {
            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository
              .Setup(m => m.Categories)
              .Returns(new List<Category>() { new Category { } });

            var useCase = new GetAllCategoriesUseCase(mockCategoryRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetAllCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetAllCategoriesResponse>()));

            var response = useCase.Handle(new GetAllCategoriesRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Get_All_Categories_When_Categories_Are_Empty()
        {
            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository
              .Setup(m => m.Categories)
              .Returns(new List<Category>() { });

            var useCase = new GetAllCategoriesUseCase(mockCategoryRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetAllCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetAllCategoriesResponse>()));

            var response = useCase.Handle(new GetAllCategoriesRequest(), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
