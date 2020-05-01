using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Presenters;

namespace Web.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IGetCategoriesUseCase _getCategoriesUseCase;
        private readonly GetCategoriesPresenter _getCategoriesPresenter;

        public NavigationMenuViewComponent(IGetCategoriesUseCase getCategoriesUseCase, GetCategoriesPresenter getCategoriesPresenter)
        {
            _getCategoriesUseCase = getCategoriesUseCase;
            _getCategoriesPresenter = getCategoriesPresenter;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await _getCategoriesUseCase.Handle(new GetCategoriesRequest(), _getCategoriesPresenter);

            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_getCategoriesPresenter.Categories);
        }
    }
}
