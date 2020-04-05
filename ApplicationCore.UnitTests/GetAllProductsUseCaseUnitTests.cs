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
              .Setup(m => m.GetAllProducts)
              .Returns(new List<Product>() { new Product { } });

            var useCase = new GetAllProductsUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetAllProductsResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetAllProductsResponse>()));

            var response = useCase.Handle(new GetAllProductsRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Get_All_Products_When_Products_Empty()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.GetAllProducts)
              .Returns(new List<Product>());

            var useCase = new GetAllProductsUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetAllProductsResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetAllProductsResponse>()));

            var response = useCase.Handle(new GetAllProductsRequest(), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
