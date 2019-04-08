using EShopping.Service.ProductTypeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopping.Data.Models;
using EShopping.Models;
using EShopping.Areas.Admin.Models;

namespace EShopping.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        private IProductTypeService _PTypeService;
        public ProductTypeController(IProductTypeService PTypeService)
        {
            _PTypeService = PTypeService;
        }
        public ActionResult Index()
        {
            var model = _PTypeService.AllProducttype().
                Select(pt => new ProductTypeViewModel
                {
                    ProductType_Id = pt.ProductType_Id,
                    Name = pt.Name,
                    Description = pt.Description,
                    Active = pt.Active
                });
            return View(model);
        }
    }
}