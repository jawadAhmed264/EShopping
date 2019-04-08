using EShopping.Service.ProductTypeServices;
using System.Linq;
using System.Web.Mvc;
using EShopping.Areas.Admin.Models;
using System.Threading.Tasks;
using EShopping.Data.Models;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Active = populateStatusCombo();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductType pt = new ProductType();
                pt.Name= model.Name;
                pt.Description= model.Description;
                pt.Active = model.Active;
                bool res = await _PTypeService.AddP_Type(pt);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var pt = _PTypeService.GetP_TypeById(Id);

            var ptViewmodel = new ProductTypeViewModel()
            {
                ProductType_Id = pt.ProductType_Id,
                Name = pt.Name,
                Description = pt.Description,
                Active = pt.Active
            };
            ViewBag.Active = populateStatusCombo();
            return View(ptViewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductType pt= _PTypeService.GetP_TypeById(model.ProductType_Id);
                pt.Name= model.Name;
                pt.Description = model.Description;
                pt.Active = model.Active;
                bool res = await _PTypeService.UpdateP_Type(pt);
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
            var pt = _PTypeService.GetP_TypeById(Id);
            ProductTypeViewModel model = new ProductTypeViewModel()
            {
                ProductType_Id = pt.ProductType_Id,
                Name = pt.Name
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {
            var attribute = _PTypeService.GetP_TypeById(model.Id);
            var res = await _PTypeService.Remove(attribute);
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