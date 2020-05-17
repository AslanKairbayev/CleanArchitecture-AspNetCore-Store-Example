using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.DTO;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Presenters;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IGetUnshippedOrdersUseCase _getUnshippedOrdersUseCase;
        private readonly GetUnshippedOrdersPresenter _getUnshippedOrdersPresenter;
        private readonly IMarkOrderShippedUseCase _markOrderShippedUseCase;
        private readonly MarkOrderShippedPresenter _markOrderShippedPresenter;
        private readonly ICheckoutUseCase _checkoutUseCase;
        private readonly CheckoutPresenter _checkoutPresenter;

        public OrderController(IGetUnshippedOrdersUseCase getUnshippedOrdersUseCase, GetUnshippedOrdersPresenter getUnshippedOrdersPresenter,
            IMarkOrderShippedUseCase markOrderShippedUseCase, MarkOrderShippedPresenter markOrderShippedPresenter,
            ICheckoutUseCase checkoutUseCase, CheckoutPresenter checkoutPresenter)
        {
            _getUnshippedOrdersUseCase = getUnshippedOrdersUseCase;
            _getUnshippedOrdersPresenter = getUnshippedOrdersPresenter;
            _markOrderShippedUseCase = markOrderShippedUseCase;
            _markOrderShippedPresenter = markOrderShippedPresenter;
            _checkoutUseCase = checkoutUseCase;
            _checkoutPresenter = checkoutPresenter;            
        }

        [Authorize]
        [HttpGet("GetUnshippedOrders")]
        public async Task<IActionResult> List()
        {
            await _getUnshippedOrdersUseCase.Handle(new GetUnshippedOrdersRequest(), _getUnshippedOrdersPresenter);
            return _getUnshippedOrdersPresenter.JsonResult;
        }

        [HttpPost("MarkShipped{orderId}")]
        [Authorize]
        public async Task<IActionResult> MarkShipped(int orderId)
        {
            await _markOrderShippedUseCase.Handle(new MarkOrderShippedRequest(orderId), _markOrderShippedPresenter);
            return _markOrderShippedPresenter.JsonResult;
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout([FromBody] OrderModel order)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _checkoutUseCase.Handle(
                new CheckoutRequest(order.Name, order.Line1, order.State, order.City, order.Country, order.Zip, order.Line2, order.Line3, order.GiftWrap), _checkoutPresenter);
            return _checkoutPresenter.JsonResult;           
        }
    }
}