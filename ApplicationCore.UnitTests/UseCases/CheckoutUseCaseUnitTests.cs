using ApplicationCore.Dto.RepositoryResponses.OrderRepository;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.DTO;
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
    public class CheckoutUseCaseUnitTests
    {
        [Fact]
        public async void Can_Checkout()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(repo => repo.Create(It.IsAny<Order>()))
              .Returns(Task.FromResult(new CreateOrderResponse(It.IsAny<int>(), true)));

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.Lines())
              .Returns(GetLines());

            var useCase = new CheckoutUseCase(mockOrderRepository.Object, mockCartRepository.Object);

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
              .Setup(repo => repo.Create(It.IsAny<Order>()))
              .Returns(Task.FromResult(new CreateOrderResponse(It.IsAny<int>(), true)));

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.Lines())
              .Returns(GetEmptyLines());

            var useCase = new CheckoutUseCase(mockOrderRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<CheckoutResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CheckoutResponse>()));

            var response = await useCase.Handle(new CheckoutRequest("name", "line1", "city", "state", "country"), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public async void Cant_Checkout_When_Request_Is_Incorrect()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(repo => repo.Create(It.IsAny<Order>()))
              .Returns(Task.FromResult(new CreateOrderResponse(It.IsAny<int>(), true)));

            var mockCartRepository = new Mock<ICartRepository>();

            mockCartRepository
              .Setup(repo => repo.Lines())
              .Returns(GetLines());

            var useCase = new CheckoutUseCase(mockOrderRepository.Object, mockCartRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<CheckoutResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CheckoutResponse>()));

            var response = await useCase.Handle(new CheckoutRequest("name", "", "city", "state", "country"), mockOutputPort.Object);

            Assert.False(response);
        }

        public async Task<IEnumerable<CartLine>> GetLines()
        {
            var lines = new List<CartLine>();

            lines.Add(new CartLine());

            return await Task.FromResult(lines);
        }

        public async Task<IEnumerable<CartLine>> GetEmptyLines()
        {
            var lines = new List<CartLine>();

            return await Task.FromResult(lines);
        }
    }
}
