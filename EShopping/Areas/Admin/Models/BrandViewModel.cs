using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class BrandViewModel
    {
        public int Brand_Id { get; set; }

        [Required]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        [Required]
        [Display(Name = "Brand Image")]
        public string Logo { get; set; }

        [Required]
        [Display(Name = "Brand Description")]
        public string Description { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }
    }
}