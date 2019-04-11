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
        EShopping.Data.Models.Attribute GetAttributeById(int Id);
        Task<bool> AddAttribute(EShopping.Data.Models.Attribute att);
        Task<bool> UpdateAttribute(EShopping.Data.Models.Attribute att);
        Task<bool> RemoveAttribute(EShopping.Data.Models.Attribute att);

    }
}
