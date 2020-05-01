using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses
{
    public class GetCategoriesResponse : ResponseMessage
    {
        public IEnumerable<string> Categories { get; }

        public GetCategoriesResponse(IEnumerable<string> categories, bool success = false, string message = null) : base(success, message)
        {
            Categories = categories;
        }
    }
}
