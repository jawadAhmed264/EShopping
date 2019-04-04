using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Models;
using EShopping.Data.Models;

namespace EShopping.Service.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> AllProducts();
        Product GetCategoryById(int Id);
        Task<bool> AddProducts(Product pro);
        Task<bool> UpdateProducts(Product pro);
        Task<bool> Remove(Product pro);
    }
}
