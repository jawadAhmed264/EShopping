using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int Product_Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Purchase Price")]
        public Nullable<decimal> PurchasePrice { get; set; }
        [Required]
        [Display(Name = "Sales Price")]
        public Nullable<decimal> SalesPrice { get; set; }
        [Required]
        [Display(Name = "Discount")]
        public Nullable<decimal> Discount { get; set; }
        [Required]
        [Display(Name = "SKU")]
        public string SKU { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public Nullable<int> Supplier_Id { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public Nullable<int> Brand_Id { get; set; }
        [Required]
        [Display(Name = "Category")]
        public Nullable<int> Category_Id { get; set; }
        [Required]
        [Display(Name = "ProductType")]
        public Nullable<int> ProductType_Id { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public Nullable<int> Rating_Id { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Modified Date")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Required]
        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }
        [Required]
        [Display(Name = "Is Featured")]
        public Nullable<bool> IsFeatured { get; set; }
    }
}