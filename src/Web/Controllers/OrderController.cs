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
        public async Task<ViewResult> List()
        {
            await _getUnshippedOrdersUseCase.Handle(new GetUnshippedOrdersRequest(), _getUnshippedOrdersPresenter);

            return View(_getUnshippedOrdersPresenter.ViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MarkShipped(int orderId)
        {
            await _markOrderShippedUseCase.Handle(new MarkOrderShippedRequest(orderId));

            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new OrderModel());

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderModel order)
        {           
            if (!ModelState.IsValid)
            {
                return View(order);
            }            

            if (!(await _checkoutUseCase.Handle(new CheckoutRequest(
                order.Name, order.Line1, order.State, order.City, order.Country, order.Zip, order.Line2, order.Line3, order.GiftWrap)
                , _checkoutPresenter)))
            {
                ModelState.AddModelError("", _checkoutPresenter.Message);
                return View(order);
            }

            return RedirectToAction(nameof(Completed));            
        }

        public ViewResult Completed()
        {
            return View();
        }
    }
}