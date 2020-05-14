using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        public ProductsListViewModel ViewModel { get; }

        public GetProductsByParamPresenter()
        {
            ViewModel = new ProductsListViewModel();            
        }

        public void Handle(GetProductsByParamResponse response)
        {
            ViewModel.Products = response.Products;
            ViewModel.CurrentCategory = response.Category;
            ViewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = response.Page,
                ItemsPerPage = response.PageSize,
                TotalItems = response.TotalItems
            };
        }
    }
}
