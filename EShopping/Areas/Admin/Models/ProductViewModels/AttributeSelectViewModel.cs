using EShopping.Areas.Admin.Models.AttributeViewModels;
using System;
using System.Collections.Generic;

namespace EShopping.Areas.Admin.Models.ProductViewModels
{
    public class AttributeSelectViewModel
    {
        public Nullable<int> AttributeId { get; set; }
        public IList<AttributeViewModel> AttributeList { get; set; }
        public string AttributeValue { get; set; }
    }
}