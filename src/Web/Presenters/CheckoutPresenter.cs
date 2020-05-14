using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public sealed class CheckoutPresenter : IOutputPort<CheckoutResponse>
    {
        public string Message { get; private set; }

        public void Handle(CheckoutResponse response)
        {
            Message = response.Message;
        }
    }
}
