using ApplicationCore.Dto.RepositoryResponses.CartRepository;
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
    public class RemoveFromCartUseCaseTests
    {
        [Fact]
        public void Can_Remove_From_Cart()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(new Product());

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.RemoveLine(It.IsAny<Product>()))
              .Returns(new RemoveLineResponse(true));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveFromCartResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveFromCartResponse>()));

            var response = useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void CanT_Remove_From_Cart_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(It.IsAny<Product>());

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.RemoveLine(It.IsAny<Product>()))
              .Returns(new RemoveLineResponse(true));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveFromCartResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveFromCartResponse>()));

            var response = useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
