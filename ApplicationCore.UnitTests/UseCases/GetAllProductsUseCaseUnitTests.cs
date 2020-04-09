using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interactors;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetAllProductsUseCaseUnitTests
    {
        [Fact]
        public void Can_Get_All_Products()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.ProductsWithCategories)
              .Returns(new List<Product>() { new Product { Category = new Category { } } });

            var useCase = new GetProductsWithCategoriesUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsWithCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsWithCategoriesResponse>()));

            var response = useCase.Handle(new GetProductsWithCategoriesRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Get_All_Products_When_Products_Are_Empty()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.ProductsWithCategories)
              .Returns(new List<Product>());

            var useCase = new GetProductsWithCategoriesUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsWithCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsWithCategoriesResponse>()));

            var response = useCase.Handle(new GetProductsWithCategoriesRequest(), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
