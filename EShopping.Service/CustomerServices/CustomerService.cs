using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private Repository<Customer> _CustRepo;

        public  CustomerService(Repository<Customer> CustRepo)
        {
            _CustRepo = CustRepo;
        }
        public IEnumerable<Customer> AllCustomers()
        {
            return _CustRepo.GetAll();
        }

        public Customer GetCustomerById(int Id)
        {
            return _CustRepo.GetById(Id);
        }
    }
}
