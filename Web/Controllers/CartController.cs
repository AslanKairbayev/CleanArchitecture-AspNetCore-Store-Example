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
        private readonly IRemoveFromCartUseCase _removeFromCartUseCase;

        public CartController(IGetCartUseCase getCartUseCase, GetCartPresenter getCartPresenter
            , IAddToCartUseCase addToCartUseCase
            , IRemoveFromCartUseCase removeFromCartUseCase)
        {
            _getCartUseCase = getCartUseCase;
            _getCartPresenter = getCartPresenter;
            _addToCartUseCase = addToCartUseCase;
            _removeFromCartUseCase = removeFromCartUseCase;
        }

        public async Task<ViewResult> Index(string returnUrl)
        {
            await _getCartUseCase.Handle(new GetCartRequest(), _getCartPresenter);

            _getCartPresenter.ViewModel.ReturnUrl = returnUrl;

            return View(_getCartPresenter.ViewModel);
        }

        public async Task<RedirectToActionResult> AddToCart(int productId, string returnUrl)
        {
            await _addToCartUseCase.Handle(new AddToCartRequest(productId));

            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int productId, string returnUrl)
        {
            await _removeFromCartUseCase.Handle(new RemoveFromCartRequest(productId));

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}