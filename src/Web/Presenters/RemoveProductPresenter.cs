using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class RemoveProductPresenter : IOutputPort<RemoveProductResponse>
    {
        public JsonResult JsonResult { get; }

        public RemoveProductPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(RemoveProductResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
