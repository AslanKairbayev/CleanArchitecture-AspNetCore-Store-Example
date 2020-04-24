using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Presenters
{
    public sealed class AddToCartPresenter : IOutputPort<AddToCartResponse>
    {
        public AddToCartPresenter()
        {

        }

        public void Handle(AddToCartResponse response)
        {

        }
    }
}
