using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetAllCategoriesResponse : ResponseMessage
    {
        public IEnumerable<CategoryDto> Categories { get; set; }

        public GetAllCategoriesResponse(IEnumerable<CategoryDto> categories, bool success = false, string message = null) : base(success, message)
        {
            Categories = categories;
        }
    }
}
