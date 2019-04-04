using EShopping.Areas.Admin.Models;
using EShopping.Service.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _ProService;
        public ProductController(IProductService ProService)
        {
            _ProService = ProService;
        }
        public ActionResult Index()
        {
            var model = _ProService.AllProducts().
                Select(p => new ProductViewModel
                {
                    Active = p.Active,
                    Brand_Id = p.Brand_Id,
                    Category_Id = p.Category_Id,
                    CreatedBy = p.CreatedBy,
                    CreatedDate = p.CreatedDate,
                    Description = p.Description,
                    Discount = p.Discount,
                    ImageUrl = p.ImageUrl,
                    IsFeatured = p.IsFeatured,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedDate = p.ModifiedDate,
                    Name = p.Name,
                    ProductType_Id = p.ProductType_Id,
                    Product_Id = p.Product_Id,
                    PurchasePrice = p.PurchasePrice,
                    Quantity = p.Quantity,
                    Rating_Id = p.Rating_Id,
                    SalesPrice = p.SalesPrice,
                    SKU = p.SKU,
                    Supplier_Id = p.Supplier_Id
                });
            return View(model);
        }
    }
}