using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Core.Dto;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Infrastructure;
using Web.Models;
using Web.Models.ViewModels;
using Web.Presenters;
using Web.Services;

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
            , IAddToCartUseCase addToCartUseCase, AddToCartPresenter addToCartPresenter
            , IRemoveFromCartUseCase removeFromCartUseCase, RemoveFromCartPresenter removeFromCartPresenter)
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

            _getCartPresenter.CartIndexViewModel.ReturnUrl = returnUrl;

            return View(_getCartPresenter.CartIndexViewModel);
        }

        public async Task<RedirectToActionResult> AddToCart(int productId, string returnUrl)
        {
            await _addToCartUseCase.Handle(new AddToCartRequest(productId), _addToCartPresenter);        

            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int productId, string returnUrl)
        {
            await _removeFromCartUseCase.Handle(new RemoveFromCartRequest(productId), _removeFromCartPresenter);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}