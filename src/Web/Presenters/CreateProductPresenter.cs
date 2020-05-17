using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class CreateProductPresenter : IOutputPort<CreateProductResponse>
    {
        public JsonResult JsonResult { get; }

        public CreateProductPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(CreateProductResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
