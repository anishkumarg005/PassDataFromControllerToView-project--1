using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassDataFromControllerToView.Models
{
    public class Product
    {
        public int Id { get; set; } 

        [Required(ErrorMessage="Product Name is Required.")]
        [Display(Name="Product Name")]
        [StringLength(100, ErrorMessage="Product Name should be less than or 100 characters long. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Price is Required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Supplier is Required.")]
        [DataType(DataType.MultilineText)]
        public string Supplier { get; set; }    
    }
}