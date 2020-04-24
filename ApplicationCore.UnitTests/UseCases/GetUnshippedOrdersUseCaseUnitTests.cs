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
    public class GetUnshippedOrdersUseCaseUnitTests
    {
        [Fact]
        public async void Can_Get_Unshipped_Orders()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(m => m.UnshippedOrdersWithLines())
              .Returns(GetUnshippedOrdersWithLines());

            var useCase = new GetUnshippedOrdersUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetUnshippedOrdersResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetUnshippedOrdersResponse>()));

            var response = await useCase.Handle(new GetUnshippedOrdersRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Get_Unshipped_Orders_When_No_Unshipped_Orders()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            mockOrderRepository
              .Setup(m => m.UnshippedOrdersWithLines())
              .Returns(GetEmptyUnshippedOrdersWithLines());

            var useCase = new GetUnshippedOrdersUseCase(mockOrderRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetUnshippedOrdersResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetUnshippedOrdersResponse>()));

            var response = await useCase.Handle(new GetUnshippedOrdersRequest(), mockOutputPort.Object);

            Assert.False(response);
        }

        public async Task<IEnumerable<Order>> GetUnshippedOrdersWithLines()
        {
            var items = new List<Order>();

            items.Add(new Order() {Lines = new List<CartLine>() { new CartLine() {Product = new Product() } } });

            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<Order>> GetEmptyUnshippedOrdersWithLines()
        {
            var items = new List<Order>();

            return await Task.FromResult(items);
        }
    }
}
