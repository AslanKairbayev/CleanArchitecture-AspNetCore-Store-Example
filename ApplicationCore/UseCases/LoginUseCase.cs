using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository repository;

        public LoginUseCase(IUserRepository repo)
        {
            repository = repo;
        }

        public bool Handle(LoginRequest request, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
                var user = repository.FindByName(request.UserName);

                if (user != null)
                {
                    if (repository.CheckPassword(user, request.Password))
                    {
                        outputPort.Handle(new LoginResponse(true));

                        return true;
                    }
                }
            }

            outputPort.Handle(new LoginResponse(false, "Invalid request"));

            return false;
        }
    }
}
