using Core.Dto.UseCaseRequests;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Presenters;

namespace Web.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly IGetCartUseCase _getCartUseCase;
        private readonly GetCartPresenter _getCartPresenter;

        public CartSummaryViewComponent(IGetCartUseCase getCartUseCase, GetCartPresenter getCartPresenter)
        {
            _getCartUseCase = getCartUseCase;
            _getCartPresenter = getCartPresenter;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await _getCartUseCase.Handle(new GetCartRequest(), _getCartPresenter);

            return View(_getCartPresenter.ViewModel);
        }
    }
}
