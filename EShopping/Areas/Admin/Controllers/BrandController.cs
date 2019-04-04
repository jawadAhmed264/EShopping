using EShopping.Areas.Admin.Models;
using EShopping.Service.BrandServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService _BrandService;

        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        public ActionResult Index()
        {
            var model = _BrandService.AllBrands().
                Select(b => new BrandViewModel
                {
                    BrandName = b.BrandName,
                    Description = b.Description,
                    Logo = b.Logo,
                    Active = b.Active     
            });
            return View(model);
        }
    }
}