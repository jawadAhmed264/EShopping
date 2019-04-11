using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
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
                    Brand_Id=b.Brand_Id,
                    BrandName = b.BrandName,
                    Description = b.Description,
                    LogoUrl = b.Logo,
                    Active = b.Active
                });
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Active = populateStatusCombo();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                Brand brand = new Brand();
                if (model.BrandLogo != null && model.BrandLogo.ContentLength != 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.BrandLogo.FileName);
                    string extension = Path.GetExtension(model.BrandLogo.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    brand.Logo = "~/Images/BrandLogo/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/BrandLogo/"), filename);
                    model.BrandLogo.SaveAs(filename);
                }
                brand.Logo = model.LogoUrl;
                brand.BrandName = model.BrandName;
                brand.Description = model.Description;
                brand.Active = model.Active;
                bool res = await _BrandService.AddBrand(brand);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var brand = _BrandService.GetBrandById(Id);

            var brandVm = new BrandViewModel()
            {
                Brand_Id = brand.Brand_Id,
                BrandName = brand.BrandName,
                Description = brand.Description,
                LogoUrl = brand.Logo,
                Active = Convert.ToBoolean(brand.Active),
            };
            ViewBag.Active = populateStatusCombo();
            return View(brandVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                Brand brand = _BrandService.GetBrandById(model.Brand_Id);

                if (model.BrandLogo != null && model.BrandLogo.ContentLength != 0)
                {
                    System.IO.File.Delete(Server.MapPath(model.LogoUrl));
                    string filename = Path.GetFileNameWithoutExtension(model.BrandLogo.FileName);
                    string extension = Path.GetExtension(model.BrandLogo.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    brand.Logo = "~/Images/BrandLogo/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/BrandLogo/"), filename);
                    model.BrandLogo.SaveAs(filename);
                }
                else
                {
                    brand.Logo = model.LogoUrl;
                }

                brand.BrandName = model.BrandName;
                brand.Description = model.Description;
                brand.Active = model.Active;
                bool res = await _BrandService.UpdateBrand(brand);
                if (res)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var category = _BrandService.GetBrandById(Id);
            BrandViewModel cvm = new BrandViewModel()
            {
                Brand_Id = category.Brand_Id,
                BrandName = category.BrandName ,
                LogoUrl = category.Logo
            };
            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(BrandViewModel model)
        {
            var category = _BrandService.GetBrandById(model.Brand_Id );
            var res = await _BrandService .Remove(category);
            if (res)
            {
                System.IO.File.Delete(Server.MapPath(model.LogoUrl));
                ModelState.Clear();
            }
            return RedirectToAction("Index");

        }

        public IList<SelectListItem> populateStatusCombo()
        {
            IList<SelectListItem> StatusSelection = new List<SelectListItem>{
                 new SelectListItem {Text="Active", Value=true.ToString(),Selected=true},
                 new SelectListItem {Text="Inactive", Value=false.ToString()}
            };

            return StatusSelection;
        }
    }
}