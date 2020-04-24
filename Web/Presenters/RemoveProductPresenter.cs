using Core.Dto.UseCaseResponses;
using Core.Interfaces;
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
