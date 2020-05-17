using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class CheckoutPresenter : IOutputPort<CheckoutResponse>
    {
        public JsonResult JsonResult { get; }

        public CheckoutPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(CheckoutResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
