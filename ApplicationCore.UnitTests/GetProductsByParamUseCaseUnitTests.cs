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
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetProductsByParamUseCaseUnitTests
    {
        [Fact]
        public void Can_Get_Products_By_Param()
        {         
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.GetProductsByPaginationAndCategory(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
              .Returns(new List<Product>() { new Product { } });

            var useCase = new GetProductsByParamUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsByParamResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsByParamResponse>()));

            var response = useCase.Handle(new GetProductsByParamRequest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), mockOutputPort.Object);

            Assert.True(response);
        }
    }
}
