using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class GetProductsPresenter : IOutputPort<GetProductsResponse>
    {
        public JsonResult JsonResult { get; }

        public GetProductsPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(GetProductsResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
