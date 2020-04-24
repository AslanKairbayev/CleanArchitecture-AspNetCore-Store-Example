using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Presenters
{
    public sealed class GetProductsByParamPresenter : IOutputPort<GetProductsByParamResponse>
    {
        public ProductsListViewModel ProductsListViewModel { get; }

        public GetProductsByParamPresenter()
        {
            ProductsListViewModel = new ProductsListViewModel();
        }

        public void Handle(GetProductsByParamResponse response)
        {
            ProductsListViewModel.Products = response.Products;
            ProductsListViewModel.CurrentCategory = response.Category;
            ProductsListViewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = response.Page,
                ItemsPerPage = response.PageSize,
                TotalItems = response.TotalItems
            };
        }
    }
}
