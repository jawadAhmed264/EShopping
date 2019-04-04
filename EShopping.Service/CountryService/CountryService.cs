using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.CountryService
{
    public class CountryService : ICountryService
    {
        private Repository<Country> _CountryRepo;

        public CountryService(Repository<Country> CountryRepo) {
            _CountryRepo = CountryRepo;
        }
        public IEnumerable<Country> getAll()
        {
            return _CountryRepo.GetAll();
        }
    }
}
