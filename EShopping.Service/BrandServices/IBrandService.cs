using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;

namespace EShopping.Service.BrandServices
{
    public interface IBrandService
    {
        IEnumerable<EShopping.Data.Models.Brand> AllBrands();

        EShopping.Data.Models.Brand GetBrandById(int id);

        Task<bool> AddBrand(EShopping.Data.Models.Brand brand);

        Task<bool> UpdateBrand(EShopping.Data.Models.Brand brand);

        Task<bool> Remove(EShopping.Data.Models.Brand brand);

    }
}
