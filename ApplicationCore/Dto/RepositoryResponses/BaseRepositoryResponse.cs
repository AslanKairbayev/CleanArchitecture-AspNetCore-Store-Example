using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.Repository
{
    public abstract class BaseRepositoryResponse
    {
        public bool Success { get; }

        protected BaseRepositoryResponse(bool success = false)
        {
            Success = success;
        }
    }
}
