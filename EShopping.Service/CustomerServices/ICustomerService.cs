using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.CustomerServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> AllCustomers();

        Customer GetCustomerById(int Id);
    }
}
