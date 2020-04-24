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

            var response = await useCase.Handle(new AddNewProductRequest("name", "description", It.IsAny<decimal>(), It.IsAny<string>()), mockOutputPort.Object);

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

            var response = await useCase.Handle(new AddNewProductRequest("name", "description", null, It.IsAny<string>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
