using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.SupplierServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierService _SuppService;
        
        public SupplierController(ISupplierService SuppService)
        {
            _SuppService = SuppService;
        }

        public ActionResult Index()
        {
            var model = _SuppService.AllSuppliers().
                Select(c => new SupplierViewModel
                {
                    Supplier_Id = c.Supplier_Id,
                    CompanyName = c.CompanyName,
                    Address1 = c.Address1,
                    Address2 = c.Address2,
                    City = c.City,
                    ContactFName = c.ContactFName,
                    ContactLName = c.ContactLName,
                    Country = c.Country,
                    Email = c.Email,
                    Phone = c.Phone,
                    State = c.State,
                    URL = c.URL
                });
            return View(model);
        }
    }
}