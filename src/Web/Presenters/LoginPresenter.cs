using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        public JsonResult JsonResult { get; }

        public LoginPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(LoginResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
