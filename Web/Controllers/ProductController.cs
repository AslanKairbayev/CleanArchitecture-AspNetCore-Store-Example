using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
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

        public async Task<IActionResult> List(string category, int page)
        {
            await _getProductsByParamUseCase.Handle(new GetProductsByParamRequest(page, category), _getProductsByParamPresenter);

            return View(_getProductsByParamPresenter.ProductsListViewModel);
        }

        
    }
}