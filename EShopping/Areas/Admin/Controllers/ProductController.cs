using EShopping.Areas.Admin.Models;
using EShopping.Areas.Admin.Models.AttributeViewModels;
using EShopping.Areas.Admin.Models.ProductViewModel;
using EShopping.Areas.Admin.Models.ProductViewModels;
using EShopping.Data.Models;
using EShopping.Service.AttributeService;
using EShopping.Service.BrandServices;
using EShopping.Service.CategoryServices;
using EShopping.Service.ProductService;
using EShopping.Service.ProductTypeServices;
using EShopping.Service.SupplierServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _ProService;
        private ISupplierService _SuppService;
        private IBrandService _BrandService;
        private ICategoryService _CatService;
        private IProductTypeService _PtService;
        private IAttributeService _attService;

        public ProductController
            (
                IProductService ProService,
                ISupplierService SuppService,
                IBrandService BrandService,
                ICategoryService CatService,
                IProductTypeService PtService,
                IAttributeService attService
             )
        {
            _ProService = ProService;
            _SuppService = SuppService;
            _BrandService = BrandService;
            _CatService = CatService;
            _PtService = PtService;
            _attService = attService;
        }
        public ActionResult Index()
        {
            var model = _ProService.AllProducts().
                Select(p => new ProductIndexViewModel
                {
                    Active = p.Active,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsFeatured = Convert.ToBoolean(p.IsFeatured),
                    Name = p.Name,
                    Product_Id = p.Product_Id,

                });
            return View(model);
        }

        public ActionResult Create() {
            ProductCreateViewModel model = new ProductCreateViewModel();
            model = populateDropdown(model);
            ViewBag.Active = populateStatusCombo();
            return View(model);
        }
        public ActionResult Attribute(int Id) {
            IList<AttributeSelectViewModel> attributeSelectList = _attService.AttributeByProductType(Id).
                Select(m=>new AttributeSelectViewModel {
                    AttributeId=m.Attribute_Id,
                    AttributeValue="",
                }).ToList();
            ViewBag.AttributeDropDown = _attService.AttributeByProductType(Id).ToList();
            ProductCreateViewModel attributeListModel = new ProductCreateViewModel();
            attributeListModel.AttributeValueList = attributeSelectList;
            return PartialView("_Attr", attributeListModel);
        }

        public ActionResult AddProductVariation(ProductCreateViewModel model) {
            ViewBag.SelectedAttr = model.AttributeValueList.Count;
            return PartialView("AddProductVariation", model);
        }
       
        private ProductCreateViewModel populateDropdown(ProductCreateViewModel model) {
            model.BrandList = _BrandService.AllActiveBrands().Select(b=>new BrandViewModel
            {
                Brand_Id=b.Brand_Id,
                BrandName=b.BrandName
            }).ToList();

            model.SupplierList = _SuppService.AllSuppliers().Select(s => new SupplierViewModel
            {
                Supplier_Id = s.Supplier_Id,
                CompanyName = s.CompanyName
            }).ToList();

            model.CategoryList= _CatService.GetActiveCategory().Select(c => new CategoryViewModel
            {
                Category_Id = c.Category_Id,
                Name = c.Name
            }).ToList();

            model.ProductTypeList = _PtService.GetActiveProdictTypes().Select(pt => new ProductTypeViewModel
            {
                ProductType_Id = pt.ProductType_Id,
                Name = pt.Name
            }).ToList();

            return model;
        }
        public IList<SelectListItem> populateStatusCombo()
        {
            IList<SelectListItem> StatusSelection = new List<SelectListItem>{
                 new SelectListItem {Text="Active", Value=true.ToString(),Selected=true},
                 new SelectListItem {Text="Inactive", Value=false.ToString()}
            };

            return StatusSelection;
        }

        public JsonResult getAttributeValues(int attributeId) {
            var attributevalueList = _attService.getValuesByAttributeId(attributeId)
                .Select(m=>new AttributeValueViewModel {
                    AttributeValue_Id=m.AttributeValue_Id,
                    Attribute_Id=m.Attribute_Id,
                    Value=m.Value
                }).ToList();
            return Json(attributevalueList,JsonRequestBehavior.AllowGet);
        }
    }
}