using Core.Dto;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.UnitTests
{
    public class RemoveFromCartUseCaseTests
    {
        [Fact]
        public async void Can_Remove_From_Cart()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(new Product()));

            var mockCartService = new Mock<ICartService>();
            mockCartService
              .Setup(repo => repo.Lines)
              .Returns(GetLines());
            mockCartService
              .Setup(repo => repo.RemoveLine(It.IsAny<ProductDto>()));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartService.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveFromCartResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveFromCartResponse>()));

            var response = await useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Remove_From_Cart_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Product>()));

            var mockCartService = new Mock<ICartService>();
            mockCartService
              .Setup(repo => repo.Lines)
              .Returns(GetLines());
            mockCartService
              .Setup(repo => repo.RemoveLine(It.IsAny<ProductDto>()));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartService.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveFromCartResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveFromCartResponse>()));

            var response = await useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public async void Cant_Remove_From_Cart_When_Cart_Is_Empty()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Product>()));

            var mockCartService = new Mock<ICartService>();
            mockCartService
              .Setup(repo => repo.Lines)
              .Returns(GetEmptyLines());
            mockCartService
              .Setup(repo => repo.RemoveLine(It.IsAny<ProductDto>()));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartService.Object);

            var mockOutputPort = new Mock<IOutputPort<RemoveFromCartResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RemoveFromCartResponse>()));

            var response = await useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }

        public IEnumerable<CartLineDto> GetLines()
        {
            var lines = new List<CartLineDto>();
            lines.Add(new CartLineDto(new ProductDto(0, null, null, 0, null), 1));
            return lines;
        }

        public IEnumerable<CartLineDto> GetEmptyLines()
        {
            var lines = new List<CartLineDto>();
            return lines;
        }
    }
}
