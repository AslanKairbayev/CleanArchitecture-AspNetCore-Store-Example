using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public class RemoveProductPresenter : IOutputPort<RemoveProductResponse>
    {
        public void Handle(RemoveProductResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
