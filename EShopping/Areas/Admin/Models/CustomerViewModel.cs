using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class CustomerViewModel
    {
        public int Customer_Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ContactNo { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public Nullable<int> AddressId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string User_Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public Nullable<bool> Active { get; set; }
    }
}