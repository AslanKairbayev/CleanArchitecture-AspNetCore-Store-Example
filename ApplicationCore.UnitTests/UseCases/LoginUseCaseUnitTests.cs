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
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Can_Login()
        {
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User(It.IsAny<string>())));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var useCase = new LoginUseCase(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            var response = await useCase.Handle(new LoginRequest("userName", "password"), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Login_When_Invalid_Request()
        {
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User(It.IsAny<string>())));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
               .Returns(Task.FromResult(true));

            var useCase = new LoginUseCase(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_User_Not_Found()
        {
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
               .Returns(Task.FromResult(It.IsAny<User>()));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                 .Returns(Task.FromResult(true));

            var useCase = new LoginUseCase(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            var response = await useCase.Handle(new LoginRequest("userName", "password"), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_Password_Incorrect()
        {
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User(It.IsAny<string>())));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                 .Returns(Task.FromResult(false));

            var useCase = new LoginUseCase(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            var response = await useCase.Handle(new LoginRequest("userName", "password"), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
