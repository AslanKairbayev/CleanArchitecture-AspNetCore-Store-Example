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
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class AddNewProductUseCaseUnitTests
    {
        [Fact]
        public async void Can_Add_New_Product()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.Create(It.IsAny<Product>()))
              .Returns(Task.FromResult(new CreateProductResponse(It.IsAny<int>(), true)));

            var useCase = new AddNewProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<AddNewProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<AddNewProductResponse>()));

            var response = await useCase.Handle(new AddNewProductRequest("name", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Add_New_Product_When_Request_Is_Invalid()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.Create(It.IsAny<Product>()))
              .Returns(Task.FromResult(new CreateProductResponse(It.IsAny<int>(), true)));

            var useCase = new AddNewProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<AddNewProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<AddNewProductResponse>()));

            var response = await useCase.Handle(new AddNewProductRequest("name", "description", null, It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
