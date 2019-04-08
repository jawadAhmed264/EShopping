using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.AttributeService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class AttributeController : Controller
    {
        private IAttributeService _AttService;
        
        public AttributeController(IAttributeService AttService)
        {
            _AttService = AttService;
        }
        public ActionResult Index()
        {
            var model = _AttService.AllAttribute().
                Select(a => new AttributeViewModel
                {
                    Attribute_Id = a.Attribute_Id,
                    AttributeName = a.AttributeName,
                    AttributeValue = a.AttributeValue,
                    Description = a.Description,
                    Active = a.Active
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
        public async Task<ActionResult> Create(AttributeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Attribute attribute= new Attribute();
                attribute.AttributeName = model.AttributeName;
                attribute.AttributeValue = model.AttributeValue;
                attribute.Description = model.Description;
                attribute.Active = model.Active;
                bool res = await _AttService.AddAttribute(attribute);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            ViewBag.Active = populateStatusCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var attribute = _AttService.GetAttributeById(Id);

            var attributeVm = new AttributeViewModel()
            {
                Attribute_Id=attribute.Attribute_Id,
                AttributeName=attribute.AttributeName,
                AttributeValue=attribute.AttributeValue,
                Description=attribute.Description,
                Active=attribute.Active
            };
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
                attribute.AttributeValue= model.AttributeValue;
                attribute.Description = model.Description;
                attribute.Active = model.Active;
                bool res = await _AttService.UpdateAttribute(attribute);
                if (res)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var attribute = _AttService.GetAttributeById(Id);
            AttributeViewModel avm = new AttributeViewModel()
            {
               Attribute_Id= attribute.Attribute_Id,
               AttributeName = attribute.AttributeName
            };
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {
            var attribute = _AttService.GetAttributeById(model.Id);
            var res = await _AttService.RemoveAttribute(attribute);
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