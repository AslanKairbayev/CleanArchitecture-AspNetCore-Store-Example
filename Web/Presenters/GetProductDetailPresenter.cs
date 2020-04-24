using ApplicationCore.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Presenters
{
    public class GetProductDetailPresenter : IOutputPort<GetProductDetailResponse>
    {
        public ProductViewModel ProductViewModel { get; set; }

        public GetProductDetailPresenter()
        {
            ProductViewModel = new ProductViewModel();
        }

        public void Handle(GetProductDetailResponse response)
        {
            ProductViewModel.Id = response.Id;
            ProductViewModel.Name = response.Name;
            ProductViewModel.Description = response.Description;
            ProductViewModel.Price = response.Price;
        }
    }
}
