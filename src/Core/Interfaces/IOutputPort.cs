using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IOutputPort<in TResponse>
    {
        void Handle(TResponse response);        
    }
}
