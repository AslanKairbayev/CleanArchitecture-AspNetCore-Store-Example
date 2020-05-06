using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Presenters
{
    public sealed class CreateProductPresenter : IOutputPort<CreateProductResponse>
    {
        public int ProductId { get; set; }

        public CreateProductPresenter()
        {
            ProductId = new int();
        }

        public void Handle(CreateProductResponse response)
        {
            ProductId = response.Id;
        }
    }
}
