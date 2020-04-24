using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Presenters;

namespace Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly GetProductsPresenter _getProductsPresenter;
        private readonly IGetProductDetailUseCase _getProductDetailUseCase;
        private readonly GetProductDetailPresenter _getProductDetailPresenter;
        private readonly IRemoveProductUseCase _removeProductUseCase;
        private readonly RemoveProductPresenter _removeProductPresenter;

        public AdminController(IGetProductsUseCase getProductsUseCase, GetProductsPresenter getProductsPresenter, 
            IGetProductDetailUseCase getProductDetailUseCase,
            GetProductDetailPresenter getProductDetailPresenter,
            IRemoveProductUseCase removeProductUseCase,
            RemoveProductPresenter removeProductPresenter)
        {
            _getProductsUseCase = getProductsUseCase;
            _getProductsPresenter = getProductsPresenter;
            _getProductDetailUseCase = getProductDetailUseCase;
            _getProductDetailPresenter = getProductDetailPresenter;
            _removeProductUseCase = removeProductUseCase;
            _removeProductPresenter = removeProductPresenter;
        }

        public async Task<ViewResult> Index()
        {
            await _getProductsUseCase.Handle(new GetProductsRequest(), _getProductsPresenter);

            return View(_getProductsPresenter.Products);
        }

        public async Task<ViewResult> Edit(int productId)
        {
            await _getProductDetailUseCase.Handle(new GetProductDetailRequest(productId), _getProductDetailPresenter);

            return View(_getProductDetailPresenter.ProductViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductRequest product)
        {
            if (ModelState.IsValid)
            {

                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new ProductRequest());

        [HttpPost]
        public async  Task<IActionResult> Delete(int productId)
        {
            await _removeProductUseCase.Handle(new RemoveProductRequest(productId), _removeProductPresenter);

            return RedirectToAction("Index");
        }
    }
}