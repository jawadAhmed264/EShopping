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

            IList<SelectListItem> StatusSelection = new List<SelectListItem>{
                new SelectListItem {Text="Active", Value=true.ToString(),Selected=true},
                 new SelectListItem {Text="Inactive", Value=false.ToString()}
            };
            ViewBag.Active = StatusSelection;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category newCat = new Category();
                string filename = Path.GetFileNameWithoutExtension(model.CategoryImage.FileName);
                string extension = Path.GetExtension(model.CategoryImage.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                newCat.ImageUrl = "~/Images/Category/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Category/"), filename);
                model.CategoryImage.SaveAs(filename);
                newCat.Name = model.Name;
                newCat.Description = model.Description;
                newCat.Active = model.Active;
                newCat.IsFeatured = model.IsFeatured;
                newCat.CreatedDate = DateTime.Now;
                bool res = await _CatService.AddCategory(newCat);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            IList<SelectListItem> StatusSelection = new List<SelectListItem>{
                new SelectListItem {Text="Active", Value=true.ToString(),Selected=true},
                 new SelectListItem {Text="Inactive", Value=false.ToString()}
            };

            ViewBag.Active = StatusSelection;
            return View(model);
        }
    }
}