using EShopping.Areas.Admin.Models;
using EShopping.Controllers;
using EShopping.Service.CategoryServices;
using System.Linq;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _CatService;
        public CategoriesController(ICategoryService CatService) {
            _CatService = CatService;
        }

        public ActionResult Index()
        {
            var model = _CatService.AllCategories().Select(c=>new CategoryViewModel {Id=c.Category_Id,Name=c.Name,Description=c.Description});
            return View(model);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid) {
               
            }
            return View();
        }

        public ActionResult Details(int Id) {
            var domainModel = _CatService.GetCategoryById(Id);
            var viewModel = new CategoryViewModel {Id=domainModel.Category_Id,Name=domainModel.Name,Description=domainModel.Description };
            return View(viewModel);
        }
    }
}