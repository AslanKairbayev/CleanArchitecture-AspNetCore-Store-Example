using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetCategoriesResponse : ResponseMessage
    {
        public IEnumerable<CategoryDto> Categories { get; }

        public GetCategoriesResponse(IEnumerable<CategoryDto> categories, bool success = false, string message = null) : base(success, message)
        {
            Categories = categories;
        }
    }
}
