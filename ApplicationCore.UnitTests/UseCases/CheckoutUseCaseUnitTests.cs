using Core.Dto;
using Core.Dto.UseCaseResponses;
using Core.DTO;
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
    public class CheckoutUseCaseUnitTests
    {
        [Fact]
        public async void Can_Checkout()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(repo => repo.Create(It.IsAny<Order>()));

            var mockCartService = new Mock<ICartService>();

            mockCartService
              .Setup(repo => repo.Lines)
              .Returns(GetLines());

            var useCase = new CheckoutUseCase(mockOrderRepository.Object, mockCartService.Object);

            var mockOutputPort = new Mock<IOutputPort<CheckoutResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CheckoutResponse>()));

            var response = await useCase.Handle(new CheckoutRequest("name", "line1", "city", "state", "country"), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Checkout_When_Cart_Is_Empty()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(repo => repo.Create(It.IsAny<Order>()));

            var mockCartService = new Mock<ICartService>();

            mockCartService
              .Setup(repo => repo.Lines)
              .Returns(GetEmptyLines());

            var useCase = new CheckoutUseCase(mockOrderRepository.Object, mockCartService.Object);

            var mockOutputPort = new Mock<IOutputPort<CheckoutResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CheckoutResponse>()));

            var response = await useCase.Handle(new CheckoutRequest("name", "line1", "city", "state", "country"), mockOutputPort.Object);

            Assert.False(response);
        }

        public IEnumerable<CartLineDto> GetLines()
        {
            var lines = new List<CartLineDto>();

            lines.Add(new CartLineDto(new ProductDto(0, null,null, 0, null), 1));

            return lines;
        }

        public IEnumerable<CartLineDto> GetEmptyLines()
        {
            var lines = new List<CartLineDto>();

            return lines;
        }
    }
}
