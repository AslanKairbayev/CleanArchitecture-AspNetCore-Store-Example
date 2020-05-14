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
                .Setup(repo => repo.MarkShipped(It.IsAny<int>()));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var response = await useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()));

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
                .Setup(repo => repo.MarkShipped(It.IsAny<int>()));

            var useCase = new MarkOrderShippedUseCase(mockOrderRepository.Object);

            var response = await useCase.Handle(new MarkOrderShippedRequest(It.IsAny<int>()));

            Assert.False(response);
        }
    }
}
