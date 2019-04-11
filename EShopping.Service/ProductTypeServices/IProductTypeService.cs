using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;

namespace EShopping.Service.ProductTypeServices
{
    public interface IProductTypeService
    { 
        IEnumerable<ProductType> AllProducttype();
        IEnumerable<ProductType> GetActiveProdictTypes();
        ProductType GetP_TypeById(int Id);
        Task<bool> AddP_Type(ProductType P_type);
        Task<bool> UpdateP_Type(ProductType P_type);
        Task<bool> Remove(ProductType P_type);
    }
}
