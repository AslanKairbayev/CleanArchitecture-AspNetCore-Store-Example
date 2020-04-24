using ApplicationCore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CartindexViewModel
    {
        public IEnumerable<CartLineDto> Lines { get; set; }
        public string ReturnUrl { get; set; }
    }
}
