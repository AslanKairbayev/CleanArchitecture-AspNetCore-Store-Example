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
              .Setup(repo => repo.RemoveLine(It.IsAny<ProductDto>()));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartService.Object);

            var response = await useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()));

            Assert.True(response);
        }

        [Fact]
        public async void CanT_Remove_From_Cart_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Product>()));

            var mockCartService = new Mock<ICartService>();

            mockCartService
              .Setup(repo => repo.RemoveLine(It.IsAny<ProductDto>()));

            var useCase = new RemoveFromCartUseCase(mockProductRepository.Object, mockCartService.Object);

            var response = await useCase.Handle(new RemoveFromCartRequest(It.IsAny<int>()));

            Assert.False(response);
        }
    }
}
