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

namespace Core.UnitTests
{
    public class UpdateProductDetailUseCaseUnitTests
    {
        [Fact]
        public async void Can_Update_Product_Detail()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()));
            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(new Product()));

            var useCase = new UpdateProductDetailUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<UpdateProductDetailResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<UpdateProductDetailResponse>()));

            var response = await useCase.Handle(
                new UpdateProductDetailRequest(It.IsAny<int>(), "name", "description", It.IsAny<decimal>(), It.IsAny<string>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Update_Product_Detail_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()));
            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(It.IsAny<Product>()));

            var useCase = new UpdateProductDetailUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<UpdateProductDetailResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<UpdateProductDetailResponse>()));

            var response = await useCase.Handle(
                new UpdateProductDetailRequest(It.IsAny<int>(), "name", "description", It.IsAny<decimal>(), It.IsAny<string>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
