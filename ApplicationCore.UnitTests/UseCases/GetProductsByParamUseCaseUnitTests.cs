using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetProductsByParamUseCaseUnitTests
    {
        [Fact]
        public async void Can_Get_Products_By_Param()
        {         
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.GetProductsByPaginationAndCategory(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
              .Returns(GetProductsByParam());

            var useCase = new GetProductsByParamUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsByParamResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsByParamResponse>()));

            var response = await useCase.Handle(new GetProductsByParamRequest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Get_Products_By_Param_When_Products_Are_Empty()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.GetProductsByPaginationAndCategory(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
              .Returns(GetEmptyProductsByParam());

            var useCase = new GetProductsByParamUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsByParamResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsByParamResponse>()));

            var response = await useCase.Handle(new GetProductsByParamRequest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), mockOutputPort.Object);

            Assert.False(response);
        }

        public async Task<IEnumerable<Product>> GetProductsByParam()
        {
            var items = new List<Product>();

            items.Add(new Product());

            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Product>> GetEmptyProductsByParam()
        {
            var items = new List<Product>();

            return await Task.FromResult(items);
        }
    }
}
