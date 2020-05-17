using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class GetUnshippedOrdersPresenter : IOutputPort<GetUnshippedOrdersResponse>
    {
        public JsonResult JsonResult { get; }

        public GetUnshippedOrdersPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(GetUnshippedOrdersResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
