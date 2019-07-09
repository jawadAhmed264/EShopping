using EShopping.Areas.Admin.Models;
using EShopping.Areas.Admin.Models.AttributeViewModels;
using EShopping.Data.Models;
using EShopping.Service.AttributeService;
using EShopping.Service.ProductTypeServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class AttributeController : Controller
    {
        private IAttributeService _AttService;
        private IProductTypeService _PTService;

        public AttributeController(IAttributeService AttService, IProductTypeService PTService)
        {
            _PTService = PTService;
            _AttService = AttService;
        }
        public ActionResult Index()
        {
            var model = _AttService.AllAttributeWithInclude(new string[] { "ProductType" }).
                Select(a => new AttributeIndexViewModel
                {
                    Attribute_Id = a.Attribute_Id,
                    AttributeName = a.AttributeName,
                    Description = a.Description,
                    Active = a.Active,
                    ProductTypeName = a.ProductType.Name
                });
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Active = populateStatusCombo();
            AttributeViewModel model = new AttributeViewModel();
            model.ProductTypeList = _PTService.GetActiveProdictTypes().Select(m => new ProductTypeViewModel
            {
                ProductType_Id = m.ProductType_Id,
                Name = m.Name
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AttributeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Attribute attribute = new Attribute();
                attribute.AttributeName = model.AttributeName;
                attribute.Description = model.Description;
                attribute.Active = model.Active;
                attribute.ProductType_Id = model.ProductType_Id;
                bool res = await _AttService.AddAttribute(attribute);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            ViewBag.Active = populateStatusCombo();
            model.ProductTypeList = _PTService.GetActiveProdictTypes().Select(m => new ProductTypeViewModel
            {
                ProductType_Id = m.ProductType_Id,
                Name = m.Name
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var attribute = _AttService.GetAttributeById(Id);

            var attributeVm = new AttributeViewModel()
            {
                Attribute_Id = attribute.Attribute_Id,
                AttributeName = attribute.AttributeName,
                Description = attribute.Description,
                Active = attribute.Active,
                ProductType_Id = attribute.ProductType_Id
            };
            ViewBag.Active = populateStatusCombo();
            attributeVm.ProductTypeList = _PTService.GetActiveProdictTypes().Select(m => new ProductTypeViewModel
            {
                ProductType_Id = m.ProductType_Id,
                Name = m.Name
            }).ToList();
            return View(attributeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AttributeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Attribute attribute = _AttService.GetAttributeById(model.Attribute_Id);
                attribute.AttributeName = model.AttributeName;
                attribute.Description = model.Description;
                attribute.ProductType_Id = model.ProductType_Id;
                attribute.Active = model.Active;
                bool res = await _AttService.UpdateAttribute(attribute);
                if (res)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Active = populateStatusCombo();
            model.ProductTypeList = _PTService.GetActiveProdictTypes().Select(m => new ProductTypeViewModel
            {
                ProductType_Id = m.ProductType_Id,
                Name = m.Name
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var attribute = _AttService.GetAttributeById(Id);
            AttributeViewModel avm = new AttributeViewModel()
            {
                Attribute_Id = attribute.Attribute_Id,
                AttributeName = attribute.AttributeName
            };
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AttributeViewModel model)
        {
            var attribute = _AttService.GetAttributeById(model.Attribute_Id);
            IEnumerable<AttributeValue> avList = _AttService.getValuesByAttributeId(model.Attribute_Id);
            bool check=await _AttService.RemoveAllAttributeValues(avList);
            if (check)
            {
                var res = await _AttService.RemoveAttribute(attribute);
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

        [HttpGet]
        public ActionResult AddAttributeValues(int AttributeId)
        {
            var attribute = _AttService.GetAttributeById(AttributeId);
            AttributeValueViewModel attVm = new AttributeValueViewModel
            {
                Attribute_Id = attribute.Attribute_Id,
                Name = attribute.AttributeName
            };
            return View(attVm);
        }

        [HttpPost]
        public async Task<ActionResult> AddAttributeValues(AttributeValueViewModel model)
        {
            if (ModelState.IsValid)
            {
                AttributeValue av = new AttributeValue
                {
                    Value = model.Value,
                    Attribute_Id = model.Attribute_Id
                };
                bool res = await _AttService.AddAttributeValue(av);
                return RedirectToAction("AddAttributeValues", new { AttributeId = model.Attribute_Id });
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteAttributeValue(int AttributeId, int AttributeValueId)
        {
            AttributeValue av = _AttService.getAttributeValueById(AttributeValueId);
            bool res=await _AttService.RemoveAttributeValue(av);
            return RedirectToAction("AddAttributeValues", new { AttributeId = AttributeId });
        }
        [ChildActionOnly]
        public ActionResult AttributeValueList(int AttributeId)
        {
            var model = _AttService.getValuesByAttributeId(AttributeId).
                Select(m => new AttributeValueListViewModel { AttributeValue_Id = m.AttributeValue_Id, Value = m.Value, Attribute_Id = m.Attribute_Id });
            return PartialView("_AttributeValueList", model);
        }

    }
}