using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.AttributeService
{
    public class AttributeService : IAttributeService
    {
        private Repository<EShopping.Data.Models.Attribute> _AttRepo;

        public AttributeService(Repository<EShopping.Data.Models.Attribute> AttRepo)
        {
            _AttRepo = AttRepo;
        }

        public async Task<bool> AddAttribute(Data.Models.Attribute att)
        {
            _AttRepo.Insert(att);
            return await _AttRepo.SaveChangesAsync();
        }

        public IEnumerable<Data.Models.Attribute> AllAttribute()
        {
            return _AttRepo.GetAll();
        }

        public Data.Models.Attribute GetAttributeById(int Id)
        {
            return _AttRepo.GetById(Id);
        }
    }
}