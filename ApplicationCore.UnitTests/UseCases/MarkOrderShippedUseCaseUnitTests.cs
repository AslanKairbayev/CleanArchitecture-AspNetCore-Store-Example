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
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class MarkOrderShippedUseCaseUnitTests
    {
        [Fact]
        public void Can_Mark_Order_Shipped()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
                .Setup(repo => repo.GetOrderById(It.IsAny<int>()))
                .Returns(new Order());

            mockOrderRepository
                .Setup(repo => repo.Update(It.IsAny<Order>()))
                .Returns(new MarkShippedResponse(true));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<MarkOrderShippedResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<MarkOrderShippedResponse>()));

            var response = useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Mark_Order_Shipped_When_Order_Not_Found()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
                .Setup(repo => repo.GetOrderById(It.IsAny<int>()))
                .Returns(It.IsAny<Order>());

            mockOrderRepository
                .Setup(repo => repo.Update(It.IsAny<Order>()))
                .Returns(new MarkShippedResponse(true));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<MarkOrderShippedResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<MarkOrderShippedResponse>()));

            var response = useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
