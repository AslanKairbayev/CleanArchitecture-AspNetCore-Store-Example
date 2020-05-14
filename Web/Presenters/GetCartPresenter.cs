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
        public CartIndexViewModel ViewModel { get; }

        public GetCartPresenter()
        {
            ViewModel = new CartIndexViewModel();
        }

        public void Handle(GetCartResponse response)
        {
            ViewModel.Lines = response.Lines;
            ViewModel.TotalValue = response.TotalValue;
        }
    }
}
