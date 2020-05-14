using Core.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Presenters
{
    public sealed class GetProductDetailPresenter : IOutputPort<GetProductDetailResponse>
    {
        public ProductModel ViewModel { get; }

        public GetProductDetailPresenter()
        {
            ViewModel = new ProductModel();
        }

        public void Handle(GetProductDetailResponse response)
        {
            ViewModel.Id = response.Id;
            ViewModel.Name = response.Name;
            ViewModel.Description = response.Description;
            ViewModel.Price = response.Price;
            ViewModel.Category = response.Category;
        }
    }
}
