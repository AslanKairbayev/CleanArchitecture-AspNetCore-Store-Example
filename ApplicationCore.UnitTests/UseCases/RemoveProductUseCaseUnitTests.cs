using Core.Dto.RepositoryResponses.ProductRepository;
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
    public class RemoveProductUseCaseUnitTests
    {
        [Fact]
        public async void Can_Remove_Product()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Delete(It.IsAny<Product>()))
              .Returns(Task.FromResult(new DeleteProductResponse(true)));

            mockProductRepository
             .Setup(m => m.GetProductById(It.IsAny<int>()))
             .Returns(Task.FromResult(new Product()));

            var useCase = new RemoveProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveProductResponse>()));

            var response = await useCase.Handle(new RemoveProductRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Remove_Product_When_Product_Is_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Delete(It.IsAny<Product>()))
              .Returns(Task.FromResult(new DeleteProductResponse(true)));

            mockProductRepository
             .Setup(m => m.GetProductById(It.IsAny<int>()))
             .Returns(Task.FromResult(It.IsAny<Product>()));

            var useCase = new RemoveProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveProductResponse>()));

            var response = await useCase.Handle(new RemoveProductRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
