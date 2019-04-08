using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.ShipperServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class ShipperController : Controller
    {
        private IShipperService _ShiService;
        public ShipperController(IShipperService ShiService)
        {
            _ShiService = ShiService;
        }
        public ActionResult Index()
        {
            var model = _ShiService.AllShipper().
                Select(s => new ShipperViewModel
                {
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                    Shipper_Id = s.Shipper_Id   
                });
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShipperViewModel model)
        {
            if (ModelState.IsValid)
            {
                Shipper shipper = new Shipper();
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                bool res = await _ShiService.AddShipper(shipper);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var shipper = _ShiService.GetShipperById(Id);

            var shipperVm = new ShipperViewModel()
            {
                Shipper_Id=shipper.Shipper_Id,
                CompanyName = shipper.CompanyName,
                Phone=shipper.Phone,
            };
            return View(shipperVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShipperViewModel model)
        {
            if (ModelState.IsValid)
            {
                Shipper shipper = _ShiService.GetShipperById(model.Shipper_Id);
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                bool res = await _ShiService.UpdateShipper(shipper);
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
            var shipper = _ShiService.GetShipperById(Id);
            ShipperViewModel svm = new ShipperViewModel()
            {
                Shipper_Id  = shipper.Shipper_Id, 
                CompanyName=shipper.CompanyName,
                Phone=shipper.Phone
            };
            return View(svm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {
            var category = _ShiService.GetShipperById(model.Id);
            var res = await _ShiService.Remove(category);
            return RedirectToAction("Index");

        }
    }
}