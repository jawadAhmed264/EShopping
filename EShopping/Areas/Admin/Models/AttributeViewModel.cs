using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopping.Areas.Admin.Models
{
    public class AttributeViewModel
    {
        public int Attribute_Id { get; set; }

        [Required]
        public string AttributeName { get; set; }

        [Required]
        public string AttributeValue { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Nullable<bool> Active { get; set; }
    }
}