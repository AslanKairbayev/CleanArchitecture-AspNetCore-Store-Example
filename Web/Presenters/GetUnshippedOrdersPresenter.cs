using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

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
        }
    }
}
