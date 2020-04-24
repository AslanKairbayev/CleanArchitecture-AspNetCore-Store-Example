using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public class MarkOrderShippedPresenter : IOutputPort<MarkOrderShippedResponse>
    {

        public void Handle(MarkOrderShippedResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
