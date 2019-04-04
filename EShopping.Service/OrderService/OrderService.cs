using EShopping.Service.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.Order
{
    public class OrderService : IOrderService
    {
        private Repository<EShopping.Data.Models.Order> _OrdRepo;

        public OrderService(Repository<EShopping.Data.Models.Order> OrdRepo)
        {
            _OrdRepo = OrdRepo;
        }
        public async Task<bool> AddOrder(Data.Models.Order ord)
        {
            _OrdRepo.Insert(ord);
            return await _OrdRepo.SaveChangesAsync();
        }

        public IEnumerable<Data.Models.Order> AllOrders()
        {
            return _OrdRepo.GetAll();
        }

        public Data.Models.Order GetOrderById(int Id)
        {
            return _OrdRepo.GetById(Id);
        }

        public async Task<bool> Remove(Data.Models.Order ord)
        {
            _OrdRepo.Delete(ord);
            return await _OrdRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrder(Data.Models.Order ord)
        {
            _OrdRepo.Update(ord);
            return await _OrdRepo.SaveChangesAsync();
        }
    }
}
