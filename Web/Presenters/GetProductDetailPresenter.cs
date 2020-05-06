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
    public class GetProductDetailPresenter : IOutputPort<GetProductDetailResponse>
    {
        public EditProduct EditProductViewModel { get; set; }

        public GetProductDetailPresenter()
        {
            EditProductViewModel = new EditProduct();
        }

        public void Handle(GetProductDetailResponse response)
        {
            EditProductViewModel.Id = response.Id;
            EditProductViewModel.Name = response.Name;
            EditProductViewModel.Description = response.Description;
            EditProductViewModel.Price = response.Price;
            EditProductViewModel.Category = response.Category;
        }
    }
}
