using EShopping.Areas.Admin.Models;
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
                Select(p => new ProductViewModel
                {
                    Active = p.Active,
                    Brand_Id = p.Brand_Id,
                    Category_Id = p.Category_Id,
                    CreatedBy = p.CreatedBy,
                    CreatedDate = p.CreatedDate,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsFeatured = Convert.ToBoolean(p.IsFeatured),
                    ModifiedBy = p.ModifiedBy,
                    ModifiedDate = p.ModifiedDate,
                    Name = p.Name,
                    ProductType_Id = p.ProductType_Id,
                    Product_Id = p.Product_Id,
                    Supplier_Id = p.Supplier_Id
                });
            return View(model);
        }
        public ActionResult Create() {
            ProductViewModel model = new ProductViewModel();
            model = populateDropdown(model);
            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        public ActionResult Attribute(int Id) {
            IEnumerable<AttributeValue> attributeValues = _attService.AttributeValuesByProductType(Id);
            IEnumerable<AttributeSelectViewModel> attributeSelectValues=attributeValues.Select(m => new AttributeSelectViewModel
            {
                AttributeId = m.Attribute_Id,
                AttributeValueId = m.AttributeValue_Id,
                Value = m.Attribute.AttributeName + "-" + m.Value,
                IsChecked = false
            });
            AttributeSelectListViewModel attributeListModel = new AttributeSelectListViewModel();
            attributeListModel.AttributeValueList = attributeSelectValues.ToList();
            return PartialView("_Attr", attributeListModel);
        }

        public ActionResult AddProductVariation() {
            return PartialView("AddProductVariation");
        }
        private ProductViewModel populateDropdown(ProductViewModel model) {
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
    }
}