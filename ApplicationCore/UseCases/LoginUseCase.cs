using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository repository;

        public LoginUseCase(IUserRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(LoginRequest request, IOutputPort<LoginResponse> outputPort)
        {
            var user = await repository.FindByName(request.UserName);

            if (user != null)
            {
                await repository.SignOut();
                if (await repository.SignIn(user, request.Password))
                {
                    outputPort.Handle(new LoginResponse(true));

                    return true;
                }
            }

            outputPort.Handle(new LoginResponse(false, $"User {request.UserName} not found"));

            return false;
        }
    }
}
