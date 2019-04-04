using EShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Service.CountryService
{
    public interface ICountryService
    {
        IEnumerable<Country> getAll();

    }
}
