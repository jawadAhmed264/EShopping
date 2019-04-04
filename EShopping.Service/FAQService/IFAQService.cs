using EShopping.Data.Models;
using EShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Service.FAQService
{
    public interface IFAQService
    {
        IEnumerable<FAQ> AllFAQ();
        FAQ GetFAQById(int id);

        Task<bool> AddFAQ(FAQ FAQ);

        Task<bool> UpdateFAQ(FAQ FAQ);

        Task<bool> Remove(FAQ FAQ);
    }
}
