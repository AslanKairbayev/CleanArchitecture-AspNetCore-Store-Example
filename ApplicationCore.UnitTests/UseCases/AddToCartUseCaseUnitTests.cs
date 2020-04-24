using Core.Dto.RepositoryResponses.CartRepository;
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
    public class AddToCartUseCaseUnitTests
    {
        [Fact]
        public async void Can_Add_To_Cart()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(new Product()));

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.AddItem(It.IsAny<Product>(), It.IsAny<int>()))
              .Returns(Task.FromResult(new AddItemResponse(true)));

            var useCase = new AddToCartUseCase(mockProductRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<AddToCartResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<AddToCartResponse>()));

            var response = await useCase.Handle(new AddToCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Add_To_Cart_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Product>()));

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.AddItem(It.IsAny<Product>(), It.IsAny<int>()))
              .Returns(Task.FromResult(new AddItemResponse(true)));

            var useCase = new AddToCartUseCase(mockProductRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<AddToCartResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<AddToCartResponse>()));

            var response = await useCase.Handle(new AddToCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }

}
