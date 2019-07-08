using EShopping.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EShopping.Areas.Admin.Models.ProductViewModel
{
    public class ProductIndexViewModel
    {
        public int Product_Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase ProductImage { get; set; }
        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }
        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; }
    }

    public class ProductCreateViewModel
    {
        public int Product_Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Purchase Price")]
        public IList<Nullable<decimal>> PurchasePrice { get; set; }
        [Required]
        [Display(Name = "Sales Price")]
        public IList<Nullable<decimal>> SalesPrice { get; set; }
        [Required]
        [Display(Name = "Discount")]
        public IList<Nullable<decimal>> Discount { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public IList<Nullable<int>> Quantity { get; set; }
        [Required]
        [Display(Name = "SKU")]
        public IList<string> SKU { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public Nullable<int> Supplier_Id { get; set; }
        public IList<SupplierViewModel> SupplierList { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public Nullable<int> Brand_Id { get; set; }
        public IList<BrandViewModel> BrandList { get; set; }
        [Required]
        [Display(Name = "Category")]
        public Nullable<int> Category_Id { get; set; }
        public IList<CategoryViewModel> CategoryList { get; set; }
        [Required]
        [Display(Name = "ProductType")]
        public Nullable<int> ProductType_Id { get; set; }
        public IList<ProductTypeViewModel> ProductTypeList { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase ProductImage { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }
        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; }
        public IList<AttributeSelectViewModel> AttributeValueList { get; set; }
    }
}