using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class MarkOrderShippedPresenter : IOutputPort<MarkOrderShippedResponse>
    {
        public JsonResult JsonResult { get; }

        public MarkOrderShippedPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(MarkOrderShippedResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
