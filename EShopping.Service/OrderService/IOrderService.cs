using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EShopping.Service.OrderService
{
    public interface IOrderService
    {
        IEnumerable<EShopping.Data.Models.Order> AllOrders();
        EShopping.Data.Models.Order GetOrderById(int Id);
        Task<bool> AddOrder(EShopping.Data.Models.Order ord);
        Task<bool> UpdateOrder(EShopping.Data.Models.Order ord);
        Task<bool> Remove(EShopping.Data.Models.Order ord);
    }
}
