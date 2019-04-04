using System.Web.Mvc;

namespace EShopping.Areas.Admin.Models
{
    public class SupplierViewModel
    {
        public int Supplier_Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactFName { get; set; }
        public string ContactLName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public SelectList CountryList { get; set; }
        public int CountryId { get; set; }
    }
}