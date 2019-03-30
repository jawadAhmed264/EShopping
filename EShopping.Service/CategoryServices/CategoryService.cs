using System.Collections.Generic;
using EShopping.Data.Models;
using EShopping.Data;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EShopping.Service.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private Repository<Category> _CatRepo;
        public CategoryService(Repository<Category> CatRepo) {
            _CatRepo = CatRepo;
        }
        public IEnumerable<Category> AllCategories()
        {
            return _CatRepo.GetAll().OrderByDescending(m=>m.Name);
        }
        public async Task<bool> AddCategory(Category cat) {
            _CatRepo.Insert(cat);
            return await _CatRepo.SaveChangesAsync();
        }

        public Category GetCategoryById(int Id)
        {
            return _CatRepo.GetById(Id);
        }
    }
}
