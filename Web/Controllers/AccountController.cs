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
    public class AccountController : Controller
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;
        private readonly ILogoutUseCase _logoutUseCase;

        public AccountController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter,
            ILogoutUseCase logoutUseCase)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
            _logoutUseCase = logoutUseCase;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (await _loginUseCase.Handle(new LoginRequest(loginModel.Name, loginModel.Password), _loginPresenter))
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                }                                                 
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _logoutUseCase.Handle(new LogoutRequest());
            return Redirect(returnUrl);
        }
    }
}