using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using Web.Models.ViewModels;
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
        private readonly ICreateNewProductUseCase _createProductUseCase;
        private readonly IUpdateProductDetailUseCase _updateProductDetailUseCase;
        private readonly IRemoveProductUseCase _removeProductUseCase;

        public AdminController(IGetProductsUseCase getProductsUseCase, GetProductsPresenter getProductsPresenter, 
            IGetProductDetailUseCase getProductDetailUseCase, GetProductDetailPresenter getProductDetailPresenter,
            ICreateNewProductUseCase createProductUseCase, 
            IUpdateProductDetailUseCase updateProductDetailUseCase, 
            IRemoveProductUseCase removeProductUseCase)
        {
            _getProductsUseCase = getProductsUseCase; _getProductsPresenter = getProductsPresenter;
            _getProductDetailUseCase = getProductDetailUseCase; _getProductDetailPresenter = getProductDetailPresenter;
            _createProductUseCase = createProductUseCase;
            _updateProductDetailUseCase = updateProductDetailUseCase; 
            _removeProductUseCase = removeProductUseCase;
        }

        public async Task<ViewResult> Index()
        {
            await _getProductsUseCase.Handle(new GetProductsRequest(), _getProductsPresenter);

            return View(_getProductsPresenter.ViewModel);
        }

        public async Task<ViewResult> Edit(int productId)
        {
            await _getProductDetailUseCase.Handle(new GetProductDetailRequest(productId), _getProductDetailPresenter);

            return View(_getProductDetailPresenter.ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.Id != 0)
            {
                await _updateProductDetailUseCase.Handle(
                    new UpdateProductDetailRequest(product.Id, product.Name, product.Description, product.Price, product.Category));
            }
            else
            {
                await _createProductUseCase.Handle(new CreateProductRequest(product.Name, product.Description, product.Price, product.Category));
            }

            TempData["message"] = $"{product.Name} has been saved";

            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductModel());
        } 

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            await _removeProductUseCase.Handle(new RemoveProductRequest(productId));

            TempData["message"] = $"Product Id - {productId} was deleted";

            return RedirectToAction("Index");
        }
    }
}