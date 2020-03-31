using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRequestHandler<in TRequest>
    {
        void Handle(TRequest request);
    }

    public interface IUseCaseHandler<in TRequest, out TResponse>
    {
        void Handle(TRequest request, IOutputPort<TResponse> outputPort);
    }
}
