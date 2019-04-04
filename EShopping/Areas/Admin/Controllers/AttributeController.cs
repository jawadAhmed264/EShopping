using EShopping.Areas.Admin.Models;
using EShopping.Service.AttributeService;
using System;
using System.Collections.Generic;
using System.IO;
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
    }
}