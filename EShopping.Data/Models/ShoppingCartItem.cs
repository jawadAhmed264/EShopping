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
    
    public partial class ShoppingCartItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingCartItem()
        {
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }
    
        public int SCItem_Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> ItemQuantity { get; set; }
        public Nullable<decimal> subtotal { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
