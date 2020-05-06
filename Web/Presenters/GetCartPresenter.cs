using Core.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;
using Core.Dto;

namespace Web.Presenters
{
    public sealed class GetCartPresenter : IOutputPort<GetCartResponse>
    {
        public CartIndexViewModel CartIndexViewModel { get; }

        public GetCartPresenter()
        {
            CartIndexViewModel = new CartIndexViewModel();
        }

        public void Handle(GetCartResponse response)
        {
            CartIndexViewModel.Lines = response.Lines;
            CartIndexViewModel.TotalValue = response.TotalValue;
        }
    }
}
