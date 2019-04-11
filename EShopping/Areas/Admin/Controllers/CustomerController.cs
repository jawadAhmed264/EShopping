using EShopping.Areas.Admin.Models;
using EShopping.Service.CustomerServices;
using System.Linq;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _CusService;

        public CustomerController(ICustomerService CusService)
        {
            _CusService = CusService;
        }
        public ActionResult Index()
        {
            var model = _CusService.AllCustomers().
                Select(a => new CustomerViewModel
                {
                    FName = a.FName,
                    LName = a.LName,
                    Active = a.Active,
                    ContactNo = a.ContactNo,
                    Description = a.Description,
                    DOB = a.DOB,
                    Email = a.Email,
                    Gender = a.Gender,
                });
            return View(model);
        }
    }
}