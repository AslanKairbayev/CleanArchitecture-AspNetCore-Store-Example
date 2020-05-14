using Core.Dto;
using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public sealed class GetProductsPresenter : IOutputPort<GetProductsResponse>
    {
        public IEnumerable<ProductDto> ViewModel { get; private set; }

        public void Handle(GetProductsResponse response)
        {
            ViewModel = response.Products;
        }
    }
}
