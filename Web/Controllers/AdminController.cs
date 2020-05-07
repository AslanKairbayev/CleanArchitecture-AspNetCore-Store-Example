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
    //[Authorize]
    public class AdminController : Controller
    {
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly GetProductsPresenter _getProductsPresenter;
        private readonly IGetProductDetailUseCase _getProductDetailUseCase;
        private readonly GetProductDetailPresenter _getProductDetailPresenter;
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly CreateProductPresenter _createProductPresenter;
        private readonly IUpdateProductDetailUseCase _updateProductDetailUseCase;
        private readonly UpdateProductDetailPresenter _updateProductDetailPresenter;
        private readonly IRemoveProductUseCase _removeProductUseCase;
        private readonly RemoveProductPresenter _removeProductPresenter;
        private readonly IGetCategoriesUseCase _getCategoriesUseCase;
        private readonly GetCategoriesPresenter _getCategoriesPresenter;

        public AdminController(IGetProductsUseCase getProductsUseCase, GetProductsPresenter getProductsPresenter, 
            IGetProductDetailUseCase getProductDetailUseCase, GetProductDetailPresenter getProductDetailPresenter,
            ICreateProductUseCase createProductUseCase, CreateProductPresenter createProductPresenter,
            IUpdateProductDetailUseCase updateProductDetailUseCase, UpdateProductDetailPresenter updateProductDetailPresenter,
            IRemoveProductUseCase removeProductUseCase, RemoveProductPresenter removeProductPresenter,
            IGetCategoriesUseCase getCategoriesUseCase, GetCategoriesPresenter getCategoriesPresenter)
        {
            _getProductsUseCase = getProductsUseCase; _getProductsPresenter = getProductsPresenter;
            _getProductDetailUseCase = getProductDetailUseCase; _getProductDetailPresenter = getProductDetailPresenter;
            _createProductUseCase = createProductUseCase; _createProductPresenter = createProductPresenter;
            _updateProductDetailUseCase = updateProductDetailUseCase; _updateProductDetailPresenter = updateProductDetailPresenter;
            _removeProductUseCase = removeProductUseCase; _removeProductPresenter = removeProductPresenter;
            _getCategoriesUseCase = getCategoriesUseCase; _getCategoriesPresenter = getCategoriesPresenter;
        }

        public async Task<ViewResult> Index()
        {
            await _getProductsUseCase.Handle(new GetProductsRequest(), _getProductsPresenter);

            return View(_getProductsPresenter.Products);
        }

        public async Task<ViewResult> Edit(int productId)
        {
            await _getProductDetailUseCase.Handle(new GetProductDetailRequest(productId), _getProductDetailPresenter);

            await _getCategoriesUseCase.Handle(new GetCategoriesRequest(), _getCategoriesPresenter);

            ViewBag.Categories = _getCategoriesPresenter.Categories;

            return View(_getProductDetailPresenter.EditProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProduct product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id != 0)
                {
                    await _updateProductDetailUseCase.Handle(
                        new UpdateProductDetailRequest(product.Id, product.Name, product.Description, product.Price, product.Category),
                        _updateProductDetailPresenter);                    
                }
                else
                {
                    await _createProductUseCase.Handle(new CreateProductRequest(product.Name, product.Description, product.Price, product.Category),
                        _createProductPresenter);
                }

                TempData["message"] = $"{product.Name} has been saved";

                return RedirectToAction("Index");
            }
            else
            {
                await _getCategoriesUseCase.Handle(new GetCategoriesRequest(), _getCategoriesPresenter);

                ViewBag.Categories = _getCategoriesPresenter.Categories;

                return View(product);
            }
        }

        public async Task<ViewResult> Create()
        {
            await _getCategoriesUseCase.Handle(new GetCategoriesRequest(), _getCategoriesPresenter);

            ViewBag.Categories = _getCategoriesPresenter.Categories;

            return View("Edit", new EditProduct());
        } 

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            await _removeProductUseCase.Handle(new RemoveProductRequest(productId), _removeProductPresenter);

            TempData["message"] = $"Product Id - {productId} was deleted";

            return RedirectToAction("Index");
        }
    }
}