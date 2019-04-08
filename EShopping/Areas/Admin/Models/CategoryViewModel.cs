using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            ImageUrl = "~/Images/default.png";
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }
        [Display(Name ="Featured Category")]
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase CategoryImage { get; set; }
    }
}