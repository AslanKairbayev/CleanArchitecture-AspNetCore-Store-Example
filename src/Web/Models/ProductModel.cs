using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter а product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter а description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter а positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify а category")]
        public string Category { get; set; }       
    }
}
