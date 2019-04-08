using System.Collections.Generic;
using System.Threading.Tasks;
using EShopping.Data.Models;
using EShopping.Data;
using System;

namespace EShopping.Service.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private Repository<Supplier> _SuppRepo;

        public SupplierService(Repository<Supplier> SupRepo)
        {
            _SuppRepo = SupRepo;
        }

        public async Task<bool> AddSupplier(Supplier supp)
        {
            _SuppRepo.Insert(supp);
            return await _SuppRepo.SaveChangesAsync();
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            return _SuppRepo.GetAll();
        }

        public Supplier GetSupplierById(int Id)
        {
            return _SuppRepo.GetById(Id);
        }

        public async Task<bool> RemoveSupplier(Supplier supp)
        {
            _SuppRepo.Delete(supp);
            return await _SuppRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateSupplier(Supplier supp)
        {
            _SuppRepo.Update(supp);
            return await _SuppRepo.SaveChangesAsync();
        }
    }
}
