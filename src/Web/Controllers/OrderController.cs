﻿using System;
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
        private readonly ICheckoutUseCase _checkoutUseCase;
        private readonly CheckoutPresenter _checkoutPresenter;

        public OrderController(IGetUnshippedOrdersUseCase getUnshippedOrdersUseCase, GetUnshippedOrdersPresenter getUnshippedOrdersPresenter,
            IMarkOrderShippedUseCase markOrderShippedUseCase,
            ICheckoutUseCase checkoutUseCase, CheckoutPresenter checkoutPresenter)
        {
            _getUnshippedOrdersUseCase = getUnshippedOrdersUseCase;
            _getUnshippedOrdersPresenter = getUnshippedOrdersPresenter;
            _markOrderShippedUseCase = markOrderShippedUseCase;
            _checkoutUseCase = checkoutUseCase;
            _checkoutPresenter = checkoutPresenter;            
        }

        [Authorize]
        [HttpGet("GetUnshippedOrders")]
        public async Task<IActionResult> List()
        {
            await _getUnshippedOrdersUseCase.Handle(new GetUnshippedOrdersRequest(), _getUnshippedOrdersPresenter);

            return Ok(_getUnshippedOrdersPresenter.ViewModel);
        }

        [HttpPost("MarkShipped{orderId}")]
        [Authorize]
        public async Task<IActionResult> MarkShipped(int orderId)
        {
            await _markOrderShippedUseCase.Handle(new MarkOrderShippedRequest(orderId));

            return Ok();
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout([FromBody] OrderModel order)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ((await _checkoutUseCase.Handle(new CheckoutRequest(
                order.Name, order.Line1, order.State, order.City, order.Country, order.Zip, order.Line2, order.Line3, order.GiftWrap)
                , _checkoutPresenter)))
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", _checkoutPresenter.Message);
                return BadRequest(ModelState);
            }          
        }
    }
}