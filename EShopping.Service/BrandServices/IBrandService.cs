using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShopping.Service.BrandServices
{
    public interface IBrandService
    {
        IEnumerable<EShopping.Data.Models.Brand> AllBrands();
        IEnumerable<EShopping.Data.Models.Brand> AllActiveBrands();
        EShopping.Data.Models.Brand GetBrandById(int id);
        Task<bool> AddBrand(EShopping.Data.Models.Brand brand);
        Task<bool> UpdateBrand(EShopping.Data.Models.Brand brand);
        Task<bool> Remove(EShopping.Data.Models.Brand brand);

    }
}
