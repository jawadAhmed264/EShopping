//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopping.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductVariant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductVariant()
        {
            this.ProductVariant_AttributeValue = new HashSet<ProductVariant_AttributeValue>();
        }
    
        public int ProductVariant_Id { get; set; }
        public Nullable<int> Product_Id { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalesPurchase { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string SKU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductVariant_AttributeValue> ProductVariant_AttributeValue { get; set; }
        public virtual Product Product { get; set; }
    }
}
