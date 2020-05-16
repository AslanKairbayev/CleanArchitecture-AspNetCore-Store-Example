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
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly ILogoutUseCase _logoutUseCase;

        public AccountController(ILoginUseCase loginUseCase,
            ILogoutUseCase logoutUseCase)
        {
            _loginUseCase = loginUseCase;
            _logoutUseCase = logoutUseCase;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _loginUseCase.Handle(new LoginRequest(loginModel.Name, loginModel.Password)))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
            
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _logoutUseCase.Handle(new LogoutRequest());
            return Ok();
        }
    }
}