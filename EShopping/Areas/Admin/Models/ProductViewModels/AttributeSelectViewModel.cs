using System;
using System.Collections.Generic;

namespace EShopping.Areas.Admin.Models.ProductViewModels
{
    public class AttributeSelectViewModel
    {
        public Nullable<int> AttributeValueId { get; set; }
        public Nullable<int> AttributeId { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
    }

    public class AttributeSelectListViewModel {
        public IList<AttributeSelectViewModel> AttributeValueList{ get; set; }
    }
}