using Core.Dto.UseCaseRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.UseCases
{
    public interface ILogoutUseCase : IRequestHandler<LogoutRequest>
    {
    }
}
