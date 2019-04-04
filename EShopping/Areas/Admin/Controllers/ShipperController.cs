using EShopping.Areas.Admin.Models;
using EShopping.Service.ShipperServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}