using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
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
    public class RemoveProductUseCaseUnitTests
    {
        [Fact]
        public void Can_Remove_Product()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Delete(It.IsAny<int>()))
              .Returns(new DeleteProductResponse(true));

            mockProductRepository
             .Setup(m => m.GetProductById(It.IsAny<int>()))
             .Returns(new Product());

            var useCase = new RemoveProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveProductResponse>()));

            var response = useCase.Handle(new RemoveProductRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Remove_Product_When_Request_Is_Invalid()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Delete(It.IsAny<int>()))
              .Returns(new DeleteProductResponse(true));

            mockProductRepository
             .Setup(m => m.GetProductById(It.IsAny<int>()))
             .Returns(new Product());

            var useCase = new RemoveProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveProductResponse>()));

            var response = useCase.Handle(new RemoveProductRequest(null), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public void Cant_Remove_Product_When_Product_Is_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Delete(It.IsAny<int>()))
              .Returns(new DeleteProductResponse(true));

            mockProductRepository
             .Setup(m => m.GetProductById(It.IsAny<int>()))
             .Returns(It.IsAny<Product>());

            var useCase = new RemoveProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveProductResponse>()));

            var response = useCase.Handle(new RemoveProductRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
