using Core.Dto.UseCaseResponses;
using Core.Interfaces;
using System.Collections.Generic;

namespace Web.Presenters
{
    public sealed class GetCategoriesPresenter : IOutputPort<GetCategoriesResponse>
    {
        public IEnumerable<string> Categories { get; private set; }

        public void Handle(GetCategoriesResponse response)
        {
            Categories = response.Categories;
        }
    }
}
