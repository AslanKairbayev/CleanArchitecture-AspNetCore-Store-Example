using ApplicationCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IOutputPort<in TResponse>
    {
        void Handle(TResponse response);        
    }
}
