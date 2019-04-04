using System.Collections.Generic;
using System.Threading.Tasks;
using EShopping.Data.Models;

namespace EShopping.Service.SupplierServices
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> AllSuppliers();

        Supplier GetSupplierById(int Id);

        Task<bool> AddSupplier(Supplier supp);
    }
}
