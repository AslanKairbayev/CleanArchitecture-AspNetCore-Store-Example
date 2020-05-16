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
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            await _getCartUseCase.Handle(new GetCartRequest(), _getCartPresenter);

            return Ok(_getCartPresenter.ViewModel);
        }

        [HttpPost("AddToCart{productId}")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            await _addToCartUseCase.Handle(new AddToCartRequest(productId));

            return Ok();
        }

        [HttpDelete("RemoveFromCart{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _removeFromCartUseCase.Handle(new RemoveFromCartRequest(productId));

            return Ok();
        }
    }
}