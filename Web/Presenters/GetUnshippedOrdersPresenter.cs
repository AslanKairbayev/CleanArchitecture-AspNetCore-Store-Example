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
    public class GetUnshippedOrdersPresenter : IOutputPort<GetUnshippedOrdersResponse>
    {
        public UnshippedOrdersViewModel UnshippedOrdersViewModel { get; }

        public GetUnshippedOrdersPresenter()
        {
            UnshippedOrdersViewModel = new UnshippedOrdersViewModel();
        }

        public void Handle(GetUnshippedOrdersResponse response)
        {
            UnshippedOrdersViewModel.Orders = response.Orders;
            UnshippedOrdersViewModel.Success = response.Success;
            UnshippedOrdersViewModel.Message = response.Message;
        }
    }
}
