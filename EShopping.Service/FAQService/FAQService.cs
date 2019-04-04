using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.FAQService
{
    public class FAQService : IFAQService
    {
        private Repository<FAQ> _FAQRepo;

        public FAQService(Repository<FAQ> FAQRepo)
        {
            _FAQRepo = FAQRepo;
        }
        public IEnumerable<FAQ> AllFAQ()
        {
            return _FAQRepo.GetAll();
        }

        public FAQ GetFAQById(int id)
        {
            return _FAQRepo.GetById(id);
        }
        public async Task<bool> AddFAQ(FAQ FAQ)
        {
            _FAQRepo.Insert(FAQ);
            return await _FAQRepo.SaveChangesAsync();
        }

        public async Task<bool> Remove(FAQ FAQ)
        {
            _FAQRepo.Delete(FAQ);
            return await _FAQRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateFAQ(FAQ FAQ)
        {
            _FAQRepo.Update(FAQ);
            return await _FAQRepo.SaveChangesAsync();
        }
    }
}
