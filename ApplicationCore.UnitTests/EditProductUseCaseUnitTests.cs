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
    public class EditProductUseCaseUnitTests
    {
        [Fact]
        public void Can_Edit_Product()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(new UpdateProductResponse(true));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(new Product());

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = useCase.Handle(new EditProductRequest(It.IsAny<int>(),"name", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Edit_Product_When_Product_Is_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(new UpdateProductResponse(true));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(It.IsAny<Product>());

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = useCase.Handle(new EditProductRequest(It.IsAny<int>(), "name", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public void Cant_Edit_Product_When_Request_Is_Invalid()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(new UpdateProductResponse(true));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(new Product());

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = useCase.Handle(new EditProductRequest(It.IsAny<int>(), "", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
