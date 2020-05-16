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
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get()
        {
            await _getProductsUseCase.Handle(new GetProductsRequest(), _getProductsPresenter);

            return Ok(_getProductsPresenter.ViewModel);
        }

        [HttpGet("GetProduct{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            await _getProductDetailUseCase.Handle(new GetProductDetailRequest(productId), _getProductDetailPresenter);

            return Ok(_getProductDetailPresenter.ViewModel);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _createProductUseCase.Handle(new CreateProductRequest(product.Name, product.Description, product.Price, product.Category));

            return Ok();
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _updateProductDetailUseCase.Handle(
                   new UpdateProductDetailRequest(product.Id, product.Name, product.Description, product.Price, product.Category));

            return Ok();
        }        

        [HttpDelete("DeleteProduct{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            await _removeProductUseCase.Handle(new RemoveProductRequest(productId));

            return NoContent();
        }
    }
}