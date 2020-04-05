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
    public class GetUnshippedOrdersUseCaseUnitTests
    {
        [Fact]
        public void Can_Get_Unshipped_Orders()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(m => m.GetUnshippedOrders)
              .Returns(new List<Order>() { new Order() { Lines = new List<CartLine>() } });

            var useCase = new GetUnshippedOrdersUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetUnshippedOrdersResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetUnshippedOrdersResponse>()));

            var response = useCase.Handle(new GetUnshippedOrdersRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public void Cant_Get_Unshipped_Orders_When_Orders_Are_Empty()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(m => m.GetUnshippedOrders)
              .Returns(new List<Order>() { });

            var useCase = new GetUnshippedOrdersUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetUnshippedOrdersResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetUnshippedOrdersResponse>()));

            var response = useCase.Handle(new GetUnshippedOrdersRequest(), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
