using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ViewModels
{
    public class UnshippedOrdersViewModel
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
