﻿using Core.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class GetProductDetailPresenter : IOutputPort<GetProductDetailResponse>
    {
        public JsonResult JsonResult { get; }

        public GetProductDetailPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(GetProductDetailResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
