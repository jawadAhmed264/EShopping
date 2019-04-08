using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class BrandViewModel
    {
        public BrandViewModel() {
            LogoUrl = "~/Images/default.png";
        }
        public int Brand_Id { get; set; }

        [Required]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        public string LogoUrl { get; set; }
        public HttpPostedFileBase BrandLogo { get; set; }

        [Required]
        [Display(Name = "Brand Description")]
        public string Description { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }
    }
}