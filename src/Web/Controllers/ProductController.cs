using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Web.Presenters;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IGetProductsByParamUseCase _getProductsByParamUseCase;
        private readonly GetProductsByParamPresenter _getProductsByParamPresenter;

        public ProductController(IGetProductsByParamUseCase getProductsByParamUseCase, GetProductsByParamPresenter getProductsByParamPresenter)
        {
            _getProductsByParamUseCase = getProductsByParamUseCase;
            _getProductsByParamPresenter = getProductsByParamPresenter;
        }

        [HttpGet("GetProductsByParam")]
        public async Task<IActionResult> Get(string category = null, int page = 1)
        {
            await _getProductsByParamUseCase.Handle(new GetProductsByParamRequest(page, category), _getProductsByParamPresenter);
            return _getProductsByParamPresenter.JsonResult;
        }        
    }
}