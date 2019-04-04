using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;

namespace EShopping.Service.ShipperServices
{
    public class ShipperService : IShipperService
    {
        private Repository<Shipper> _ShiRepo;
        public ShipperService(Repository<Shipper> ShiRepo)
        {
            _ShiRepo = ShiRepo;
        }
        public async Task<bool> AddShipper(Shipper Shi)
        {
            _ShiRepo.Insert(Shi);
            return await _ShiRepo.SaveChangesAsync();
        }

        public IEnumerable<Shipper> AllShipper()
        {
            return _ShiRepo.GetAll();
        }

        public Shipper GetShipperById(int Id)
        {
            return _ShiRepo.GetById(Id);
        }

        public async Task<bool> Remove(Shipper Shi)
        {
            _ShiRepo.Delete(Shi);
            return await _ShiRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateShipper(Shipper Shi)
        {
            _ShiRepo.Update(Shi);
            return await _ShiRepo.SaveChangesAsync();
        }
    }
}
