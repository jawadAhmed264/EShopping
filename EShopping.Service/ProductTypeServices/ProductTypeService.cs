using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.ProductTypeServices
{
    public class ProductTypeService : IProductTypeService
    {
        private Repository<ProductType> _PTypeRepo;
        public ProductTypeService(Repository<ProductType> PTypeRepo)
        {
            _PTypeRepo = PTypeRepo;
        }
        public async Task<bool> AddP_Type(ProductType P_type)
        {
            _PTypeRepo.Insert(P_type);
            return await _PTypeRepo.SaveChangesAsync();
        }

        public IEnumerable<ProductType> AllProducttype()
        {
            return _PTypeRepo.GetAll();
        }

        public ProductType GetP_TypeById(int Id)
        {
            return _PTypeRepo.GetById(Id);
        }

        public async Task<bool> Remove(ProductType P_type)
        {
            _PTypeRepo.Delete(P_type);
            return await _PTypeRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateP_Type(ProductType P_type)
        {
            _PTypeRepo.Update(P_type);
            return await _PTypeRepo.SaveChangesAsync();
        }
    }
}
