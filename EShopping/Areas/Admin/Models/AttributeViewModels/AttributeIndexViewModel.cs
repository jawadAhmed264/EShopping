using System;

namespace EShopping.Areas.Admin.Models.AttributeViewModels
{
    public class AttributeIndexViewModel
    {
        public int Attribute_Id { get; set; }

        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }

        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ProductTypeName { get; set; }
    }
}