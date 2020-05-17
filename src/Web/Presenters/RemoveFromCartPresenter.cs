using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public class RemoveFromCartPresenter : IOutputPort<RemoveFromCartResponse>
    {
        public JsonResult JsonResult { get; }

        public RemoveFromCartPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(RemoveFromCartResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
