using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class GetProductsByParamPresenter : IOutputPort<GetProductsByParamResponse>
    {
        public JsonResult JsonResult { get; }

        public GetProductsByParamPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(GetProductsByParamResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
