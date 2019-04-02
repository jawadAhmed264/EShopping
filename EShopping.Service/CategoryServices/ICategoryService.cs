using EShopping.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShopping.Service.CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> AllCategories();
        Category GetCategoryById(int Id);
        Task<bool> AddCategory(Category cat);
        Task<bool> UpdateCategory(Category cat);
        Task<bool> Remove(Category cat);

    }
}
