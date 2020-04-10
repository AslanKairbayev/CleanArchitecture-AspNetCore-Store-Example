using ApplicationCore.Dto.RepositoryResponses.OrderRepository;
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
    public class MarkOrderShippedUseCaseUnitTests
    {
        [Fact]
        public async void Can_Mark_Order_Shipped()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
                .Setup(repo => repo.GetOrderById(It.IsAny<int>()))
                .Returns(Task.FromResult(new Order()));

            mockOrderRepository
                .Setup(repo => repo.MarkShipped(It.IsAny<int>()))
                .Returns(Task.FromResult(new MarkShippedResponse(true)));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<MarkOrderShippedResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<MarkOrderShippedResponse>()));

            var response = await useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Mark_Order_Shipped_When_Order_Not_Found()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
                .Setup(repo => repo.GetOrderById(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Order>()));

            mockOrderRepository
                .Setup(repo => repo.MarkShipped(It.IsAny<int>()))
                .Returns(Task.FromResult(new MarkShippedResponse(true)));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<MarkOrderShippedResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<MarkOrderShippedResponse>()));

            var response = await useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
