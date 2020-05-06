using Core.Dto.UseCaseResponses;
using Core.Interfaces;
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
            
        }
    }
}
