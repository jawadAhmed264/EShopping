using EShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Service.AttributeService
{
    public interface IAttributeService
    {
        IEnumerable<EShopping.Data.Models.Attribute> AllAttribute();
        IEnumerable<EShopping.Data.Models.Attribute> GetActiveAttribute();
        IQueryable<EShopping.Data.Models.Attribute> AllAttributeWithInclude(string[] Includes);
        IEnumerable<Data.Models.AttributeValue> AttributeValuesByProductType(int ProductTypeId);
        IEnumerable<Data.Models.Attribute> AttributeByProductType(int ProductTypeId);
        EShopping.Data.Models.Attribute GetAttributeById(int Id);
        Task<bool> AddAttribute(EShopping.Data.Models.Attribute att);
        Task<bool> AddAttributeValue(AttributeValue attValue);
        IEnumerable<AttributeValue> getValuesByAttributeId(int AttributeId);
        AttributeValue getAttributeValueById(int AttributeValueId);
        Task<bool> RemoveAttributeValue(AttributeValue av);
        Task<bool> RemoveAllAttributeValues(IEnumerable<AttributeValue> avList);
        Task<bool> UpdateAttribute(EShopping.Data.Models.Attribute att);
        Task<bool> RemoveAttribute(EShopping.Data.Models.Attribute att);

    }
}
