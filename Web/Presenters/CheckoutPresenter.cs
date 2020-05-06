using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public class CheckoutPresenter : IOutputPort<CheckoutResponse>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public void Handle(CheckoutResponse response)
        {
            Success = response.Success;
            Message = response.Message;
        }
    }
}
