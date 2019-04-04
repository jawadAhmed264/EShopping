using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.ProductService
{
    public class ProductService : IProductService
    {
        private Repository<Product> _ProRepo;

        public ProductService(Repository<Product> ProRepo)
        {
            _ProRepo = ProRepo;
        }
        public async Task<bool> AddProducts(Product pro)
        {
            _ProRepo.Insert(pro);
            return await _ProRepo.SaveChangesAsync();
        }

        public IEnumerable<Product> AllProducts()
        {
            return _ProRepo.GetAll();
        }

        public Product GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(Product pro)
        {
            _ProRepo.Delete(pro);
            return await _ProRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateProducts(Product pro)
        {
            _ProRepo.Update(pro);
            return await _ProRepo.SaveChangesAsync();
        }
    }
}
