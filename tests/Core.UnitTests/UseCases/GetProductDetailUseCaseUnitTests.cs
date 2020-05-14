using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.UnitTests.UseCases
{
    public class GetProductDetailUseCaseUnitTests
    {
        [Fact]
        public async void Can_Get_Product_Detail()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(new Product()));

            var useCase = new GetProductDetailUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductDetailResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductDetailResponse>()));

            var response = await useCase.Handle(new GetProductDetailRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Get_Product_Detail_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(It.IsAny<Product>()));

            var useCase = new GetProductDetailUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductDetailResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductDetailResponse>()));

            var response = await useCase.Handle(new GetProductDetailRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
