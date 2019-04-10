using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.BrandServices
{
    public class BrandService : IBrandService
    {
        private Repository<EShopping.Data.Models.Brand> _BrandRepo;

        public BrandService(Repository<EShopping.Data.Models.Brand> BrandRepo)
        {
            _BrandRepo = BrandRepo;
        }
        public async Task<bool> AddBrand(Data.Models.Brand brand)
        {
            _BrandRepo.Insert(brand);
            return await _BrandRepo.SaveChangesAsync();
        }

        public IEnumerable<Brand> AllActiveBrands()
        {
            return _BrandRepo.GetAll().Where(m=>m.Active==true);
        }

        public IEnumerable<Data.Models.Brand> AllBrands()
        {
            return _BrandRepo.GetAll();
        }

        public Data.Models.Brand GetBrandById(int id)
        {
            return _BrandRepo.GetById(id);
        }

        public async Task<bool> Remove(Data.Models.Brand brand)
        {
            _BrandRepo.Delete(brand);
            return await _BrandRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateBrand(Data.Models.Brand brand)
        {
            _BrandRepo.Update(brand);
            return await _BrandRepo.SaveChangesAsync();
        }
    }
}
