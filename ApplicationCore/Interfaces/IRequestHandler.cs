using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        Task<bool> Handle(TRequest request, IOutputPort<TResponse> outputPort);
    }
}
