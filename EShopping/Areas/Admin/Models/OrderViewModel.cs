using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public int Order_Id { get; set; }
        [Required]
        public Nullable<int> Customer_Id { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public Nullable<System.DateTime> OrderDate { get; set; }
        [Required]
        [Display(Name = "Ship Date")]
        public Nullable<System.DateTime> ShipDate { get; set; }
        [Required]
        [Display(Name = "Order Amount")]
        public Nullable<decimal> OrderAmount { get; set; }
        [Required]
        [Display(Name = "Order Discount")]
        public Nullable<decimal> Discount { get; set; }
        [Required]
        [Display(Name = "Shipping Amount")]
        public Nullable<decimal> ShippingAmount { get; set; }
        [Required]
        [Display(Name = "Tax Amount")]
        public Nullable<decimal> TaxAmount { get; set; }

        [Required]
        [Display(Name = "Net Amount")]
        public Nullable<decimal> NetAmount { get; set; }

        [Required]
        [Display(Name = "Shipping Date")]
        public Nullable<System.DateTime> ShippingDate { get; set; }

        [Required]
        [Display(Name = "Shipping Address")]
        public Nullable<int> ShippingAddress_Id { get; set; }

        [Required]
        [Display(Name = "Billing Address")]
        public Nullable<int> BillingAddress_Id { get; set; }
        [Required]
        [Display(Name = "Order Status")]
        public Nullable<int> OrderStatus_Id { get; set; }
        [Required]
        [Display(Name = "Payment")]
        public Nullable<int> Payment_Id { get; set; }
        [Required]
        [Display(Name = "Shipper")]
        public Nullable<int> Shipper_Id { get; set; }
    }
}