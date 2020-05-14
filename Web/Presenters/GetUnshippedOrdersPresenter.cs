using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Presenters
{
    public sealed class GetUnshippedOrdersPresenter : IOutputPort<GetUnshippedOrdersResponse>
    {
        public UnshippedOrdersViewModel ViewModel { get; }

        public GetUnshippedOrdersPresenter()
        {
            ViewModel = new UnshippedOrdersViewModel();
        }

        public void Handle(GetUnshippedOrdersResponse response)
        {
            ViewModel.Orders = response.Orders;
            ViewModel.Success = response.Success;
            ViewModel.Message = response.Message;
        }
    }
}
