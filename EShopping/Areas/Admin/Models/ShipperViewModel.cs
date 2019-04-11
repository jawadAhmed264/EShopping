using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class ShipperViewModel
    {
        [Required]
        public int Shipper_Id { get; set; }
        [Required]
        [Display(Name = "Comapny Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}