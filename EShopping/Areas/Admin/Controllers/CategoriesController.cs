using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.CategoryServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _CatService;
        public CategoriesController(ICategoryService CatService)
        {
            _CatService = CatService;
        }

        public ActionResult Index()
        {
            var model = _CatService.AllCategories().
                Select(c => new CategoryViewModel
                {
                    Id = c.Category_Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Active = Convert.ToBoolean(c.Active),
                    IsFeatured = Convert.ToBoolean(c.IsFeatured),
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
        public async Task<ActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category newCat = new Category();
                if (model.CategoryImage != null && model.CategoryImage.ContentLength != 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.CategoryImage.FileName);
                    string extension = Path.GetExtension(model.CategoryImage.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    newCat.ImageUrl = "~/Images/Category/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/Category/"), filename);
                    model.CategoryImage.SaveAs(filename);
                }
                newCat.ImageUrl = model.ImageUrl;
                newCat.Name = model.Name;
                newCat.Description = model.Description;
                newCat.Active = model.Active;
                newCat.IsFeatured = model.IsFeatured;
                newCat.CreatedDate = DateTime.Now;
                bool res = await _CatService.AddCategory(newCat);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
           
            var category = _CatService.GetCategoryById(Id);

            var categoryVM = new CategoryViewModel()
            {
                Id = category.Category_Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                Active = Convert.ToBoolean(category.Active),
                IsFeatured = Convert.ToBoolean(category.IsFeatured)
            };
            ViewBag.Active = populateStatusCombo();
            return View(categoryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category newCat = _CatService.GetCategoryById(model.Id);

                if (model.CategoryImage != null && model.CategoryImage.ContentLength != 0)
                {
                    System.IO.File.Delete(Server.MapPath(model.ImageUrl));
                    string filename = Path.GetFileNameWithoutExtension(model.CategoryImage.FileName);
                    string extension = Path.GetExtension(model.CategoryImage.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    newCat.ImageUrl = "~/Images/Category/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/Category/"), filename);
                    model.CategoryImage.SaveAs(filename);
                }
                else
                {
                    newCat.ImageUrl = model.ImageUrl;
                }

                newCat.Name = model.Name;
                newCat.Description = model.Description;
                newCat.Active = model.Active;
                newCat.IsFeatured = model.IsFeatured;
                newCat.ModifiedDate = DateTime.Now;

                bool res = await _CatService.UpdateCategory(newCat);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id) {
            var category = _CatService.GetCategoryById(Id);
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Id= category.Category_Id,
                Name = category.Name,
                ImageUrl=category.ImageUrl
            };
            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryViewModel model) {
            var category = _CatService.GetCategoryById(model.Id);
            var res =await _CatService.Remove(category);
            if (res) {
                System.IO.File.Delete(Server.MapPath(model.ImageUrl));
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