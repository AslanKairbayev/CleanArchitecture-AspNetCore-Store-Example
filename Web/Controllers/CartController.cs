using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Interfaces.UseCases;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Web.Presenters;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IGetCartUseCase _getCartUseCase;
        private readonly GetCartPresenter _getCartPresenter;
        private readonly IAddToCartUseCase _addToCartUseCase;
        private readonly AddToCartPresenter _addToCartPresenter;
        private readonly IRemoveFromCartUseCase _removeFromCartUseCase;
        private readonly RemoveFromCartPresenter _removeFromCartPresenter;

        public CartController(IGetCartUseCase getCartUseCase, GetCartPresenter getCartPresenter
            ,IAddToCartUseCase addToCartUseCase, AddToCartPresenter addToCartPresenter
            ,IRemoveFromCartUseCase removeFromCartUseCase, RemoveFromCartPresenter removeFromCartPresenter)
        {
            _getCartUseCase = getCartUseCase;
            _getCartPresenter = getCartPresenter;
            _addToCartUseCase = addToCartUseCase;
            _addToCartPresenter = addToCartPresenter;
            _removeFromCartUseCase = removeFromCartUseCase;
            _removeFromCartPresenter = removeFromCartPresenter;
        }

        public async Task<ViewResult> Index(string returnUrl)
        {
            await _getCartUseCase.Handle(new GetCartRequest(), _getCartPresenter);

            return View(_getCartPresenter.CartindexViewModel.ReturnUrl = returnUrl);
        }

        public async Task<RedirectToActionResult> AddToCart(int productId, string returnUrl)
        {
            await _addToCartUseCase.Handle(new AddToCartRequest(productId), _addToCartPresenter);

            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int ProductId, string returnUrl)
        {
            await _removeFromCartUseCase.Handle(new RemoveFromCartRequest(ProductId), _removeFromCartPresenter);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}