using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Web.Presenters;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IGetCartUseCase _getCartUseCase;
        private readonly GetCartPresenter _getCartPresenter;
        private readonly IAddToCartUseCase _addToCartUseCase;
        private readonly AddToCartPresenter _addToCartPresenter;
        private readonly IRemoveFromCartUseCase _removeFromCartUseCase;
        private readonly RemoveFromCartPresenter _removeFromCartPresenter;

        public CartController(IGetCartUseCase getCartUseCase, GetCartPresenter getCartPresenter, 
            IAddToCartUseCase addToCartUseCase, AddToCartPresenter addToCartPresenter,
            IRemoveFromCartUseCase removeFromCartUseCase, RemoveFromCartPresenter removeFromCartPresenter)
        {
            _getCartUseCase = getCartUseCase; 
            _getCartPresenter = getCartPresenter;
            _addToCartUseCase = addToCartUseCase; 
            _addToCartPresenter = addToCartPresenter;
            _removeFromCartUseCase = removeFromCartUseCase;
            _removeFromCartPresenter = removeFromCartPresenter;
        }

        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            await _getCartUseCase.Handle(new GetCartRequest(), _getCartPresenter);
            return _getCartPresenter.JsonResult;
        }

        [HttpPost("AddToCart{productId}")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            await _addToCartUseCase.Handle(new AddToCartRequest(productId), _addToCartPresenter);
            return _addToCartPresenter.JsonResult;
        }

        [HttpDelete("RemoveFromCart{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _removeFromCartUseCase.Handle(new RemoveFromCartRequest(productId), _removeFromCartPresenter);
            return _removeFromCartPresenter.JsonResult;
        }
    }
}