using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopping.Data.Models;

namespace EShopping.Service.ShipperServices
{
    public interface IShipperService
    {
        IEnumerable<Shipper> AllShipper();
        Shipper GetShipperById(int Id);
        Task<bool> AddShipper(Shipper Shi);
        Task<bool> UpdateShipper(Shipper Shi);
        Task<bool> Remove(Shipper Shi);
    }
}
