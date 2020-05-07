using Core.Dto.UseCaseRequests;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class LogoutUseCase : ILogoutUseCase
    {
        private readonly IUserRepository repository;

        public LogoutUseCase(IUserRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(LogoutRequest request)
        {
            await repository.SignOut();

            return true;
        }
    }
}
