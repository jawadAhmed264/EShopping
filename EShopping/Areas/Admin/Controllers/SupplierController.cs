using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.CountryService;
using EShopping.Service.SupplierServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierService _SuppService;
        private ICountryService _CountryService;
        public SupplierController
            (
            ISupplierService SuppService,
            ICountryService CountryService
            )
        {
            _SuppService = SuppService;
            _CountryService = CountryService;
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

        [HttpGet]
        public ActionResult Create() {
            ViewBag.Country = new SelectList(PopulateCountry(), "CountryName", "CountryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(SupplierViewModel svm)
        {
            if (ModelState.IsValid) {
                Supplier supplier = new Supplier {
                    CompanyName=svm.CompanyName,
                    ContactFName=svm.ContactFName,
                    ContactLName=svm.ContactLName,
                    Address1=svm.Address1,
                    Address2=svm.Address2,
                    Phone=svm.Phone,
                    Email=svm.Email,
                    URL=svm.URL,
                    Country=svm.Country,
                    City=svm.City,
                    State=svm.State,
                };
               bool res= await _SuppService.AddSupplier(supplier);
               ModelState.Clear();
               return RedirectToAction("Index");
            }
            ViewBag.Country = new SelectList(PopulateCountry(), "CountryName", "CountryName");
            return View(svm);
        }

        [HttpGet]
        public ActionResult Edit(int Id) {
            var domainModel = _SuppService.GetSupplierById(Id);

            var svm = new SupplierViewModel
            {
                Supplier_Id = domainModel.Supplier_Id,
                CompanyName = domainModel.CompanyName,
                ContactFName = domainModel.ContactFName,
                ContactLName = domainModel.ContactLName,
                Address1 = domainModel.Address1,
                Address2 = domainModel.Address2,
                Phone = domainModel.Phone,
                Email = domainModel.Email,
                URL = domainModel.URL,
                Country = domainModel.Country,
                City = domainModel.City,
                State = domainModel.State,
            };

            ViewBag.Country = new SelectList(PopulateCountry(), "CountryName", "CountryName");

            return View(svm);
        }

        public IEnumerable<CountryViewModel> PopulateCountry() {
            var List = _CountryService.getAll().Select(c=>new CountryViewModel {CountryId=c.Id,CountryName=c.Name });
            return List;
        }
    }
}