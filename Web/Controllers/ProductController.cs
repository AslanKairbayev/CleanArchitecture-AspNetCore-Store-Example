using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Web.Presenters;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetProductsByParamUseCase _getProductsByParamUseCase;
        private readonly GetProductsByParamPresenter _getProductsByParamPresenter;       

        public ProductController(IGetProductsByParamUseCase getProductsByParamUseCase, GetProductsByParamPresenter getProductsByParamPresenter)
        {
            _getProductsByParamUseCase = getProductsByParamUseCase;
            _getProductsByParamPresenter = getProductsByParamPresenter;            
        }

        public async Task<IActionResult> List(string category, int productPage)
        {
            await _getProductsByParamUseCase.Handle(new GetProductsByParamRequest(productPage, 4, category), _getProductsByParamPresenter);

            return View(_getProductsByParamPresenter.ProductsListViewModel);
        }

        
    }
}