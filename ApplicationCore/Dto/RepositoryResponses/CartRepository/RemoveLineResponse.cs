using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.CartRepository
{
    public class RemoveLineResponse : BaseRepositoryResponse
    {
        public RemoveLineResponse(bool success = false) : base(success)
        {

        }
    }
}
