using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class ProductTypeViewModel
    {
        public int ProductType_Id { get; set; }

        [Required]
        [Display(Name = "Product type")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product type description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product type Status")]
        public Nullable<bool> Active { get; set; }
    }
}