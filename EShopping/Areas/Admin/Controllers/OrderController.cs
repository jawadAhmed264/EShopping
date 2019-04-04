using EShopping.Areas.Admin.Models;
using EShopping.Service.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EShopping.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _OrdService;

        public OrderController(IOrderService OrdService)
        {
            _OrdService = OrdService;
        }
        public ActionResult Index()
        {
            var model = _OrdService.AllOrders().
                Select(o => new OrderViewModel
                {
                    BillingAddress_Id = o.BillingAddress_Id,
                    Customer_Id = o.Customer_Id,
                    Discount = o.Discount,
                    NetAmount = o.NetAmount,
                    OrderAmount = o.OrderAmount,
                    OrderDate = o.OrderDate,
                    OrderStatus_Id = o.OrderStatus_Id,
                    Order_Id = o.Order_Id,
                    Payment_Id = o.Payment_Id,
                    ShipDate = o.ShipDate,
                    Shipper_Id = o.Shipper_Id,
                    ShippingAddress_Id = o.ShippingAddress_Id,
                    ShippingAmount = o.ShippingAmount,
                    ShippingDate = o.ShippingDate,
                    TaxAmount = o.TaxAmount
                });
            return View(model);
        }
    }
}