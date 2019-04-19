using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopping.Areas.Admin.Models.AttributeViewModels
{
    public class AttributeViewModel
    {
        public int Attribute_Id { get; set; }

        [Required]
        public string AttributeName { get; set; }

        [Required]
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }

        public Nullable<int> ProductType_Id { get; set; }
        public IList<ProductTypeViewModel> ProductTypeList { get; set; }
    }
}