using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;
using System;

namespace EShopping.Service.AttributeService
{
    public class AttributeService : IAttributeService
    {
        private Repository<EShopping.Data.Models.Attribute> _AttRepo;
        private Repository<AttributeValue> _AttValueRepo;

        public AttributeService(Repository<EShopping.Data.Models.Attribute> AttRepo,
            Repository<AttributeValue> AttValueRepo)
        {
            _AttValueRepo = AttValueRepo;
            _AttRepo = AttRepo;
        }

        public async Task<bool> AddAttribute(Data.Models.Attribute att)
        {
            _AttRepo.Insert(att);
            return await _AttRepo.SaveChangesAsync();
        }

        public async Task<bool> AddAttributeValue(AttributeValue attValue)
        {
            _AttValueRepo.Insert(attValue);
            return await _AttValueRepo.SaveChangesAsync();
        }

        public IEnumerable<Data.Models.Attribute> AllAttribute()
        {
            return _AttRepo.GetAll();
        }

        public IQueryable<Data.Models.Attribute> AllAttributeWithInclude(string[] Includes)
        {
            return _AttRepo.GetAllWithIncludes(Includes);
        }

        public IEnumerable<Data.Models.Attribute> GetActiveAttribute()
        {
            return _AttRepo.GetAll().Where(m => m.Active == true);
        }

        public Data.Models.Attribute GetAttributeById(int Id)
        {
            return _AttRepo.GetById(Id);
        }

        public AttributeValue getAttributeValueById(int AttributeValueId)
        {
            return _AttValueRepo.GetById(AttributeValueId);
        }

        public IEnumerable<AttributeValue> getValuesByAttributeId(int AttributeId)
        {
            return _AttValueRepo.GetAllWithIncludes(new string[] {"Attribute"}).Where(m => m.Attribute_Id == AttributeId).ToList();
        }

        public async Task<bool> RemoveAttributeValue(AttributeValue av)
        {
            _AttValueRepo.Delete(av);
            return await _AttValueRepo.SaveChangesAsync();
        }

        public async Task<bool> RemoveAttribute(Data.Models.Attribute att)
        {
            _AttRepo.Delete(att);
            return await _AttRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateAttribute(Data.Models.Attribute att)
        {
            _AttRepo.Update(att);
            return await _AttRepo.SaveChangesAsync();
        }

        public async Task<bool> RemoveAllAttributeValues(IEnumerable<AttributeValue> avList)
        {
            bool res=false;
            foreach (var item in avList) {
                res=await RemoveAttributeValue(item);
            }
            return res;
        }
    }
}