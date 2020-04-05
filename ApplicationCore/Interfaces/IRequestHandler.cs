using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        bool Handle(TRequest request, IOutputPort<TResponse> outputPort);
    }
}
