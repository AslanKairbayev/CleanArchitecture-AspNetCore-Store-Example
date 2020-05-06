using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public IEnumerable<CartLineDto> Lines { get; set; }
        public decimal TotalValue { get; set; }
        public string ReturnUrl { get; set; }        
    }
}
