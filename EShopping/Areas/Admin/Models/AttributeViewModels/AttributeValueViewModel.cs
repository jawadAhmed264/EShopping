using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopping.Areas.Admin.Models.AttributeViewModels
{
    public class AttributeValueViewModel
    {
        public int AttributeValue_Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public Nullable<int> Attribute_Id { get; set; }
    }
    public class AttributeValueListViewModel
    {
        public Nullable<int> AttributeValue_Id { get; set; }
        public Nullable<int> Attribute_Id { get; set; }
        public string Value { get; set; }
    }
}